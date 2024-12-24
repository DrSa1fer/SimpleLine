using simpleline.models;
using simpleline.models.attributes;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions;

public abstract class CommandOptionHandlerBaseT<T> : CommandOptionHandlerBase where T : IOptionAttribute
{
    public override bool Is(IOptionAttribute attribute)
    {
        return attribute is T;
    }

    public override void Handle(IOptionAttribute attribute, CommandOption commandOption, Data data)
    {
        OnHandle((T)attribute, commandOption, data);
    }

    protected abstract void OnHandle(T attribute, CommandOption commandOption, Data data);
}