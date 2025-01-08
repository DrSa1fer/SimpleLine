using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;

namespace simpleline;

public static partial class SimpleLine {
    public static void Run(IEnumerable<string> args,
        ParserConfig? parserConfig = null,
        HelperConfig? helperConfig = null,
        Assembly[]? assemblies = null
    ) {
        var services = new ServiceCollection();

        services.AddSingleton(parserConfig ?? new ParserConfig());
        services.AddSingleton(helperConfig ?? new HelperConfig());

        var assembly = assemblies ?? [Assembly.GetCallingAssembly()];
        var provider = Init(services);

        _Run(args, assembly, provider);
    }

    public static void Run(string arg,
        ParserConfig? parserConfig = null,
        HelperConfig? helperConfig = null,
        Assembly[]? assemblies = null
    ) {
        var services = new ServiceCollection();

        services.AddSingleton(parserConfig ?? new ParserConfig());
        services.AddSingleton(helperConfig ?? new HelperConfig());

        var assembly = assemblies ?? [Assembly.GetCallingAssembly()];
        var provider = Init(services);

        _Run(arg, assembly, provider);
    }
}