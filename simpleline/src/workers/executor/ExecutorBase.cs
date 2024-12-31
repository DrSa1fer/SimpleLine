using simpleline.services;

namespace simpleline.workers.executor;

internal abstract class ExecutorBase
{
    public abstract object? Execute(Context context);
}