using Microsoft.Extensions.DependencyInjection;
using simpleline.services.executor;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.binder.actionOptions;
using simpleline.services.executor.main.binder.commandOptions;
using simpleline.services.executor.main.invoker;
using simpleline.services.executor.main.typizer;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.workers.parser;
using simpleline.workers.tokenizer;

namespace simpleline;

public static partial class SimpleLine {
    private static ServiceProvider Init(IServiceCollection services) {
        services.AddScoped<CommandOptionBinderBase, CommandOptionBinder>();
        services.AddScoped<ActionOptionBinderBase, ActionOptionBinder>();
        
        services.AddScoped<TokenizerBase, Tokenizer>();
        services.AddScoped<RegistrarBase, Registrar>();
        
        services.AddScoped<ExecutorBase, Executor>();
        
        services.AddScoped<InvokerBase, Invoker>();
        services.AddScoped<TypizerBase, Typizer>();
        
        services.AddScoped<ParserBase, Parser>();
        services.AddScoped<RouterBase, Router>();
        services.AddScoped<HelperBase, Helper>();
        
        return services.BuildServiceProvider();
    }
}