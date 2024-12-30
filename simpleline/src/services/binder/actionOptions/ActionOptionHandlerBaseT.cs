using simpleline.models.options;

namespace simpleline.services.binder.actionOptions;

public abstract class ActionOptionHandlerBase<T> : ActionOptionHandlerBase where T : ICommandOptionAttribute
{
    public sealed override bool Is(ICommandOptionAttribute attribute)
    {
        return attribute is T;
    }

    public sealed override void Handle(ICommandOptionAttribute attribute, CommandOption option, Data data)
    {
        OnHandle((T)attribute, option, data);
    }

    protected abstract void OnHandle(T attribute, CommandOption option, Data data);
}