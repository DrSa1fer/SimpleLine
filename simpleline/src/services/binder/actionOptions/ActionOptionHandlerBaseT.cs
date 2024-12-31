using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions;

internal abstract class ActionOptionHandlerBase<T> : ActionOptionHandlerBase where T : IActionOptionAttribute
{
    public sealed override bool Is(IActionOptionAttribute attribute)
    {
        return attribute is T;
    }

    public sealed override void Handle(IActionOptionAttribute attribute, ActionOption option, InputData inputData)
    {
        OnHandle((T)attribute, option, inputData);
    }

    protected abstract void OnHandle(T attribute, ActionOption option, InputData inputData);
}