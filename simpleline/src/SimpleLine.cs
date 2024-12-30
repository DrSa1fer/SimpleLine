using System.Reflection;
using simpleline.models;
using simpleline.services;
using simpleline.workers.registrar;

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
        var registrar = new Registrar();
        var input = new Input(symbols);

        var types = Assembly
            .GetCallingAssembly()
            .DefinedTypes;
    }

    private static void Run(Context context)
    {
        try
        {
            // new Pipeline()
            //     .Run();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
        }
    }
}