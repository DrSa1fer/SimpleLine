using simpleline.models;
using simpleline.models.attributes;
using simpleline.models.inputs;

namespace simpleline.services.binder.actionOptions;

public abstract class ActionOptionHandlerBase<T> : ActionOptionHandlerBase where T : IOptionAttribute
{
    public sealed override bool Is(IOptionAttribute attribute)
    {
        return attribute is T;
    }

    public sealed override void Handle(IOptionAttribute attribute, CommandOption option, Data data)
    {
        OnHandle((T)attribute, option, data);
    }

    protected abstract void OnHandle(T attribute, CommandOption option, Data data);
}