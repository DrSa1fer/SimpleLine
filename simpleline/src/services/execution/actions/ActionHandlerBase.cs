using simpleline.models.attributes;
using Action = simpleline.models.Action;

namespace simpleline.services.execution.actions;

public abstract class ActionHandlerBase
{
    public abstract bool Is(IActionAttribute attribute);
    public abstract InvokeActionDelegate Handle(IActionAttribute attribute, Action action);
}