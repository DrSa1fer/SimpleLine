using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.services.executor;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.workers.parser;

namespace simpleline;

public static partial class SimpleLine
{
    private static void _Run(IEnumerable<string> args, Assembly[] assemblies, IServiceProvider provider)
    {
        var parser = provider.GetRequiredService<ParserBase>();
        var router = provider.GetRequiredService<RouterBase>();
        
        var executor = provider.GetRequiredService<ExecutorBase>();
        var registrar = provider.GetRequiredService<RegistrarBase>();

        var input = parser.Parse(args);
        var commands = registrar.Register(assemblies);

        var command = router.Route(commands, input);

        executor.Execute(command, new Data([]));
    }
}