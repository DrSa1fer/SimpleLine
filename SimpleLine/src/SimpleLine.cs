using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.exmodels.typizer;
using simpleline.services.executor;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.binder.actionOptions;
using simpleline.services.executor.main.binder.actionOptions.arguments;
using simpleline.services.executor.main.binder.actionOptions.flags;
using simpleline.services.executor.main.binder.actionOptions.parameters;
using simpleline.services.executor.main.binder.commandOptions;
using simpleline.services.executor.main.binder.commandOptions.arguments;
using simpleline.services.executor.main.binder.commandOptions.flags;
using simpleline.services.executor.main.binder.commandOptions.parameters;
using simpleline.services.executor.main.invoker;
using simpleline.services.executor.main.typizer;
using simpleline.services.registrar;
using simpleline.services.registrar.actions;
using simpleline.services.registrar.commands;
using simpleline.services.registrar.options.actions;
using simpleline.services.registrar.options.commands;
using simpleline.services.router;
using simpleline.workers.parser;
using simpleline.workers.tokenizer;
using Console = simpleline.exmodels.Console;

namespace simpleline;

public static class SimpleLine {
    public static void Run(IEnumerable<string> input,
        Console? console = null,
        HelpConfig? helpConfig = null,
        SpecialFlagConfig? helpKeys = null,
        KeyParsingConfig? parseConfig = null,
        CustomTypizerCollection? typizerCollection = null,
        Assembly[]? assemblies = null
    ) {
        var services = new ServiceCollection();

        services.AddSingleton(typizerCollection ?? new CustomTypizerCollection());
        services.AddSingleton(parseConfig ?? new KeyParsingConfig());
        services.AddSingleton(helpConfig ?? new HelpConfig());
        services.AddSingleton(helpKeys ?? new SpecialFlagConfig());
        services.AddSingleton(console ?? new Console());

        var provider = Init(services);
        var assembly = assemblies ?? [Assembly.GetCallingAssembly()];

        provider.GetRequiredService<Pipeline>().Run(input, assembly);
    }

    private static ServiceProvider Init(IServiceCollection services) {
        //Pipeline
        services.AddScoped<RegistrarBase, Registrar>();
        services.AddScoped<TokenizerBase, Tokenizer>();
        services.AddScoped<ParserBase, Parser>();
        services.AddScoped<RouterBase, Router>();
        services.AddScoped<ExecutorBase, Executor>();
        services.AddScoped<Pipeline, Pipeline>();

        //Registrars
        services.AddScoped<CommandRegistrarBase, CommandRegistrar>();
        services.AddScoped<ActionRegistrarBase, ActionRegistrar>();
        services.AddScoped<CommandOptionRegistrarBase, CommandOptionRegistrar>();
        services.AddScoped<ActionOptionRegistrarBase, ActionOptionRegistrar>();

        //Main
        services.AddScoped<InvokerBase, Invoker>();
        services.AddScoped<TypizerBase, Typizer>();

        //*CommandOptions
        services.AddScoped<CommandOptionBinderBase, CommandOptionBinder>();
        services.AddScoped<CommandParameterHandler>();
        services.AddScoped<CommandArgumentHandler>();
        services.AddScoped<CommandFlagHandler>();

        //*ActionOptions
        services.AddScoped<ActionOptionBinderBase, ActionOptionBinder>();
        services.AddScoped<ActionParameterHandler>();
        services.AddScoped<ActionArgumentHandler>();
        services.AddScoped<ActionFlagHandler>();

        //Help
        services.AddScoped<HelperBase, Helper>();

        return services.BuildServiceProvider();
    }
}