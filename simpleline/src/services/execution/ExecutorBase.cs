using simpleline.models;

namespace simpleline.services.execution;

public abstract class ExecutorBase
{
    public abstract void Execute(Input context, Controller controller);
}