using Action = simpleline.models.Action;

namespace simpleline.services.execution.actions.action;

public class ActionHandler : ActionHandlerBase<IActionAttribute>
{
    protected override InvokeActionDelegate Handle(IActionAttribute attribute, Action action)
    {
        return data =>
        {
            foreach (var o in action.Options) o.SetValue(100);

            var args = action.Options
                .Select(o => o.GetValue())
                .ToArray();

            return action.Invoke(args);
        };
    }
}