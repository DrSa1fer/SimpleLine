using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
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

namespace simpleline;

public class SimpleLineBuilder {
    public IServiceCollection Services { get; } = new ServiceCollection();
    
    public ICollection<string> HelpAliases { get; set; } = new List<string>();
    public ICollection<string> VersionAliases { get; set; } = new List<string>();

    public Configuration? Configuration { get; set; }
    public Metadata? Metadata { get; set; }

    public SimpleLine Build() {
        ConfigureServices(Services);
        
        var provider = Services.BuildServiceProvider();
        
        return new SimpleLine(provider);
    }
    
    private static ServiceProvider ConfigureServices(IServiceCollection services) {
        //configs
        services.TryAddSingleton(_ => new Configuration());
        services.TryAddSingleton(_ => new Metadata());
        
        //Pipeline
        services.AddScoped<RegistrarBase, Registrar>();
        services.AddScoped<TokenizerBase, Tokenizer>();
        services.AddScoped<ParserBase, Parser>();
        services.AddScoped<RouterBase, Router>();
        services.AddScoped<ExecutorBase, Executor>();
        services.AddScoped<Pipeline, Pipeline>();
        
        //Main
        services.AddScoped<InvokerBase, Invoker>();
        services.AddScoped<TypizerBase, Typizer>();
        services.AddScoped<MainWriter>();

        //*Binding
        services.AddScoped<BinderBase, Binder>();
        services.AddScoped<ParameterHandler>();
        services.AddScoped<ArgumentHandler>();
        services.AddScoped<FlagHandler>();
        services.AddScoped<EnvHandler>();
        
        //*Compliant
        services.AddScoped<ComplierBase, Complier>();

        //Help
        services.AddScoped<HelperBase, Helper>();
        services.AddScoped<HelpWriter>();

        return services.BuildServiceProvider();
    }
}