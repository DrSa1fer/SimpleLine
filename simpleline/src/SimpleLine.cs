using System.Reflection;
using simpleline.configs;
using simpleline.models;
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

            app = new ApplicationConfig()
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

            app = new ApplicationConfig()
            {
                DefinedTypes = types
            };
        }
        
        Run(new Input(symbols.Select(x => (Symbol)x)), app);
    }

    private static void Run(Input input, ApplicationConfig app)
    {
        var registrar = new Registrar();
        var router    = new Router();
        var executor  = new Executor();

        var context = new Context(app, input);
        
        var node = registrar
            .Register(context);
        
        var type  = router
            .Route(context, node);
        
        executor
            .Execute(context, type);
    }
}