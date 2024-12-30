using Action = simpleline.models.actions.Action;

namespace simpleline.services.invoker;

public class ActionInvoker : ActionInvokerBase
{
    public override object? Invoke(Action action, params object[] parameters)
    {
        throw new NotImplementedException();
    }
}