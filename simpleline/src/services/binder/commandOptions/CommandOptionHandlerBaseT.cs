using simpleline.models.options;

namespace simpleline.services.binder.commandOptions;

public abstract class CommandOptionHandlerBaseT<T> : CommandOptionHandlerBase where T : ICommandOptionAttribute
{
    public override bool Is(ICommandOptionAttribute attribute)
    {
        return attribute is T;
    }

    public override void Handle(ICommandOptionAttribute attribute, CommandOption commandOption, Data data)
    {
        OnHandle((T)attribute, commandOption, data);
    }

    protected abstract void OnHandle(T attribute, CommandOption commandOption, Data data);
}