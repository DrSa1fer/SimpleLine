using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using simpleline.configs;
using simpleline.services.executor;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.binder.actionOptions;
using simpleline.services.executor.main.binder.commandOptions;
using simpleline.services.executor.main.invoker;
using simpleline.services.executor.main.typizer;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.workers.parser;

namespace simpleline;

public static partial class SimpleLine
{
    private static ServiceProvider Init(IServiceCollection services)
    {
        services.TryAddTransient<ParserConfig>(_ => new ParserConfig());
        services.TryAddTransient<HelperConfig>(_ => new HelperConfig());
        
        services.AddScoped<RegistrarBase, Registrar>();
        services.AddScoped<ParserBase, Parser>();
        services.AddScoped<RouterBase, Router>();
        
        services.AddScoped<ExecutorBase, Executor>();
            services.AddScoped<InvokerBase, Invoker>();
            services.AddScoped<TypizerBase, Typizer>();
        
        services.AddScoped<ActionOptionBinderBase, ActionOptionBinder>();
        services.AddScoped<CommandOptionBinderBase, CommandOptionBinder>();
        
        return services.BuildServiceProvider();
    }
}