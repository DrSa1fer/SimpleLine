using Action = simpleline.models.actions.Action;

namespace simpleline.services.invoker;

internal abstract class ActionInvokerBase
{
    public abstract object? Invoke(IEnumerable<Action> action);
}