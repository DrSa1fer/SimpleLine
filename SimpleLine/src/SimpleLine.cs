using simpleline.services.registrar;
using simpleline.services.executor;
using simpleline.services.router;
using simpleline.services;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.workers.parser;

namespace simpleline;

public static class SimpleLine
{
    public static void Run(IEnumerable<string> args)
    {
        var provider = InitServices();

        var assembly = Assembly.GetCallingAssembly();
        
        var router = provider.GetService<RouterBase>()
                     ?? throw new ApplicationException("Router not found");
        var parser = provider.GetService<ParserBase>()
                     ?? throw new ApplicationException("Parser not found");
        var executor = provider.GetService<ExecutorBase>()
                       ?? throw new ApplicationException("Executor not found");
        var registrar = provider.GetService<RegistrarBase>()
                        ?? throw new ApplicationException("Registrar not found");
        
        var commands = registrar.Register([assembly]);
        var input = parser.Parse(args);
        
        var command = router.Route(commands, input);

        var ctx = new Context(default, command, new Data([ /*todo*/]));



        executor.Execute(ctx);
    }

    private static IServiceProvider InitServices()
    {
        return default;
    }
}