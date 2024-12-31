using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.flags;

internal class ActionFlagHandler : ActionOptionHandlerBase<IActionFlagAttribute>
{
    protected override void OnHandle(IActionFlagAttribute attribute, ActionOption option, InputData inputData)
    {
        option.SetValue(attribute.Keys
            .Any(key => inputData.TryGetValues(key, 0, out _)));
    }
}