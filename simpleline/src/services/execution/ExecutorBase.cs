using simpleline.models;

namespace simpleline.services.execution;

public abstract class ExecutorBase
{
    public abstract void Execute(Context context, Type? type);
}