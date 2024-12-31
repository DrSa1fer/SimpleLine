using System.Reflection;
using simpleline.workers.executor;
using simpleline.workers.registrar;
using simpleline.workers.router;

namespace simpleline;

public static class SimpleLine
{
    public static void Run(string input)
    {
        throw new NotImplementedException();
    }

    public static void Run(IEnumerable<string> symbols)
    {
        var registrar = new Registrar();

        var assembly = Assembly
            .GetCallingAssembly();
        
        var scopes = 
            registrar.Register([assembly]);

        var router = new Router();
        
        var command = router.Route(default, scopes);
        var executor = new Executor();
        
        executor.Execute(default);
    }
}