using simpleline.models.commands;
using simpleline.services.executor.help;
using simpleline.services.executor.main;

namespace simpleline.services.executor;

internal class Executor(IServiceProvider provider) : ExecutorBase
{
    private readonly Case[] _cases =
    [
        // new Help(provider),
        new Main(provider)
    ];

    public override void Execute(Command command, Data data)
    {
        _cases
            .First(x => x.Is(data))
            .Invoke(command, data);
    }
}