using Action = simpleline.models.actions.Action;

namespace simpleline.services.invoker;

internal class ActionInvoker : ActionInvokerBase
{
    public override object? Invoke(IEnumerable<Action> action)
    {
        return action.First().Invoke();
    }
}