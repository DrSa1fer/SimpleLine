using simpleline.models.attributes;
using Action = simpleline.models.Action;

namespace simpleline.services.execution.actions;

public abstract class ActionHandlerBase<T> : ActionHandlerBase where T : IActionAttribute
{
    public override bool Is(IActionAttribute attribute)
    {
        return attribute is T;
    }

    public override InvokeActionDelegate Handle(IActionAttribute attribute, Action action)
    {
        return Handle((T)attribute, action);
    }

    protected abstract InvokeActionDelegate Handle(T attribute, Action action);
}