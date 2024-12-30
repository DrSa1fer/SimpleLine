using simpleline.models.options;
using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions;

internal abstract class ActionOptionHandlerBase<T> : ActionOptionHandlerBase where T : IActionOptionAttribute
{
    public sealed override bool Is(IActionOptionAttribute attribute)
    {
        return attribute is T;
    }

    public sealed override void Handle(IActionOptionAttribute attribute, ActionOption option, Data data)
    {
        OnHandle((T)attribute, option, data);
    }

    protected abstract void OnHandle(T attribute, ActionOption option, Data data);
}