using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.external;
using simpleline.external.writers;
using simpleline.services.executor;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.binder.handlers.arguments;
using simpleline.services.executor.main.binder.handlers.envs;
using simpleline.services.executor.main.binder.handlers.flags;
using simpleline.services.executor.main.binder.handlers.parameters;
using simpleline.services.executor.main.complier;
using simpleline.services.executor.main.invoker;
using simpleline.services.executor.typizer;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.workers.parser;
using simpleline.workers.tokenizer;
using Binder = simpleline.services.executor.main.binder.Binder;

namespace simpleline;

public class SimpleLine(IServiceProvider provider) {
    private TokenizerBase Tokenizer => provider.GetRequiredService<TokenizerBase>(); 
    private RegistrarBase Registrar => provider.GetRequiredService<RegistrarBase>(); 
    private ExecutorBase Executor => provider.GetRequiredService<ExecutorBase>(); 
    private ParserBase Parser => provider.GetRequiredService<ParserBase>(); 
    private RouterBase Router => provider.GetRequiredService<RouterBase>(); 
    
    public void Run(string args) {
        Run(Tokenizer.Tokenize(args));
    }
    public void Run(IEnumerable<string> args) {
        var configuration = provider.GetService<Configuration>();
        
        var types = Assembly.GetCallingAssembly().DefinedTypes;
        
        var input = Parser.Parse(args);
        
        var commands = Registrar.Register(types);
        var command = Router.Route(commands, ref input);
        Executor.Execute(command, ref input);
    }
}