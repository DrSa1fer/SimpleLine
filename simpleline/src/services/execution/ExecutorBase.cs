using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.execution;

public abstract class ExecutorBase
{
    public abstract object? Execute(Context context, Command command);
}