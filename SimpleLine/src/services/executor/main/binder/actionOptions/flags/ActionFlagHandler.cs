using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions.flags;

internal class ActionFlagHandler : ActionOptionHandlerBase<IActionFlagAttribute>
{
    protected override void OnHandle(IActionFlagAttribute attribute, ActionOption option, Data data)
    {
        option.Init(attribute.Keys
            .Any(key => data.TryGetValues(key, 0, out _)));
    }
}