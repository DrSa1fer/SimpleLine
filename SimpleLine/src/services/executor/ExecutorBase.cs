using simpleline.models.commands;

namespace simpleline.services.executor;

internal abstract class ExecutorBase
{
    public abstract void Execute(Command command, Data data);
}