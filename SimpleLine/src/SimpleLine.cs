using simpleline.services.registrar;
using simpleline.services.executor;
using simpleline.services.router;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.workers.parser;

namespace simpleline;

public static partial class SimpleLine
{
    public static void Run(IEnumerable<string> args,
        ParserConfig? parserConfig = null,
        HelperConfig? helperConfig = null,
        Assembly[]? assemblies = null)
    {
        var services = new ServiceCollection();
        
        if(parserConfig != null) services.AddTransient<ParserConfig>(_ => parserConfig);
        if(helperConfig != null) services.AddTransient<HelperConfig>(_ => helperConfig);
        
        var assembly = assemblies ?? [Assembly.GetCallingAssembly()];
        var provider = Init(services);

        _Run(args, assembly, provider);
    }
}