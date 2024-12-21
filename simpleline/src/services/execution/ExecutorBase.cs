using simpleline.models;

namespace simpleline.services.execution;

public abstract class ExecutorBase
{
    public abstract object? Execute(Context context, Command command);
}