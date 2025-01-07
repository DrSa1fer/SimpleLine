using simpleline.services.executor.help;
using simpleline.services.executor.main;

namespace simpleline.services.executor;

internal class Executor : ExecutorBase
{
    private readonly Case[] _cases =
    [
        new Help(),
        new Main()
    ];

    public override void Execute(Context context)
    {
        _cases
            .First(x => x.Is(context))
            .Invoke(context);
    }
}