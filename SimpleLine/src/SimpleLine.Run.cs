using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using simpleline.services;
using simpleline.services.executor;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.workers.parser;
using simpleline.workers.tokenizer;

namespace simpleline;

public static partial class SimpleLine {
    private static void _Run(string arg, Assembly[] assemblies, IServiceProvider provider) {
        var tokenizer = provider.GetRequiredService<TokenizerBase>();
        _Run(tokenizer.Tokenize(arg), assemblies, provider);
    }

    private static void _Run(IEnumerable<string> args, Assembly[] assemblies, IServiceProvider provider) {
        var registrar = provider.GetRequiredService<RegistrarBase>();
        var executor = provider.GetRequiredService<ExecutorBase>();
        var parser = provider.GetRequiredService<ParserBase>();
        var router = provider.GetRequiredService<RouterBase>();

        var input = new Input(parser.Parse(args));

        var commands = registrar
            .Register(assemblies);

        var command = router
            .Route(commands, input);

        executor
            .Execute(command, input);
    }
}