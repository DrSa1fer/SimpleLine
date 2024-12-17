using System.Reflection;
using simpleline.configs;
using simpleline.models;
using simpleline.models.commands;
using simpleline.models.inputs;
using simpleline.services.execution;
using simpleline.services.registration;
using simpleline.services.routing;

namespace simpleline;

public static class SimpleLine
{
    public static void Run(string input, ApplicationConfig? app = null)
    {
        ArgumentNullException.ThrowIfNull(input, nameof(input));

        if (app == null)
        {
            var types = Assembly.GetCallingAssembly().DefinedTypes;

            app = new ApplicationConfig
            {
                DefinedTypes = types
            };
        }

        Run(new Input(input.Split().Select(x => (Symbol)x)), app);
    }

    public static void Run(IEnumerable<string> symbols, ApplicationConfig? app = null)
    {
        ArgumentNullException.ThrowIfNull(symbols, nameof(symbols));

        if (app == null)
        {
            var types = Assembly.GetCallingAssembly().DefinedTypes;

            app = new ApplicationConfig
            {
                DefinedTypes = types
            };
        }

        Run(new Input(symbols.Select(x => (Symbol)x)), app);
    }

    private static void Run(Input input, ApplicationConfig app)
    {
        var context = new Context(app, input);
        var registrar = new Registrar();
        
        var commands = registrar
            .Register(context);
        
        
        var router = new Router();
        var executor = new Executor();

        try
        {
            var command = router
                .Route(context, commands);

            var result = executor
                .Execute(context, command);
        }
        catch (Exception e)
        {
            
        }
    }
}