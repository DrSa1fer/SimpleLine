using Action = simpleline.models.actions.Action;

namespace simpleline.services.invoker;

public abstract class ActionInvokerBase
{
    public abstract object? Invoke(Action action, params object[] parameters);
}