using System.Reflection;
using simpleline.models.commands;
using simpleline.services;
using simpleline.services.executor;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.workers.parser;
using simpleline.workers.tokenizer;

namespace simpleline;

internal class Pipeline(
    RegistrarBase registrar,
    RouterBase router,
    ExecutorBase executor,
    TokenizerBase tokenizer,
    ParserBase parser
) {
    public void Run(string args, Assembly[] assemblies) {
        try {
            var input = new Input(parser.Parse(tokenizer.Tokenize(args)));

            var commands = registrar
                .Register(assemblies);

            var command = router
                .Route(commands, input);

            executor
                .Execute(command, input);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }

    public void Run(IEnumerable<string> args, Assembly[] assemblies) {
        try {
            var input = new Input(parser.Parse(args));

            var commands = registrar
                .Register(assemblies);

            var command = router
                .Route(commands, input);

            executor
                .Execute(command, input);
        }
        catch (Exception e) {
            Console.WriteLine(e.Message);
        }
    }
}