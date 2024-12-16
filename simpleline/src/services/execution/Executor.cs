using simpleline.models;

namespace simpleline.services.execution;

public class Executor : ExecutorBase
{
    public override void Execute(Context context, Type? type)
    {
        type?.GetMethod("Invoke")?.Invoke(Activator.CreateInstance(type), null);
    }
}