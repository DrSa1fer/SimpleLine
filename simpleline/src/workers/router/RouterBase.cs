using simpleline.models.commands;

namespace simpleline.workers.router;

internal abstract class RouterBase
{
    public abstract Command Route(Command[] commands, Input input);
}