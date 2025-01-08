using simpleline.models.commands;

namespace simpleline.services.executor;

internal abstract class Case
{
    public abstract bool Is(Data data);
    public abstract void Invoke(Command command, Data data);
}