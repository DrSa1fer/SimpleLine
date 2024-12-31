using simpleline.models.commands;

namespace simpleline.services.helper;

internal abstract class HelperBase
{
    public abstract bool Is(Command command);
    public abstract void Help(Command command);
}