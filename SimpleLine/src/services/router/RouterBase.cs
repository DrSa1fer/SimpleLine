using simpleline.models.commands;

namespace simpleline.services.router;

internal abstract class RouterBase
{
    public abstract Command Route(Command[] commands, Input input);
}