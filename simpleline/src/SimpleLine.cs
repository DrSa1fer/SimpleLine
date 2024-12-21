using System.Reflection;
using simpleline.configs;
using simpleline.models;
using simpleline.models.inputs;
using simpleline.registrars;
using simpleline.services.execution;
using simpleline.services.routing;

namespace simpleline;

public static class SimpleLine
{
    public static void Run(string input)
    {
        var types = Assembly.GetCallingAssembly().DefinedTypes;

        // Run(new Input(input.Split().Select(x => (Symbol)x)), app);
    }

    public static void Run(IEnumerable<string> symbols)
    {
        var input = new Input(symbols.Select(x => (Symbol)x));
        var asm = Assembly.GetCallingAssembly();


        Run(input, asm);
    }

    private static void Run(Input input, Assembly assembly)
    {
        var registrar = new Registrar();

        var commands = registrar
            .Register(assembly.DefinedTypes);

        var context = new Context(input)
        {
            ApplicationConfig = new ApplicationConfig(),
            Commands = commands
        };


        var router = new Router();
        var executor = new Executor();

        try
        {
            var command = router
                .Route(context);

            var result = executor
                .Execute(context, command);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
        }
    }
}