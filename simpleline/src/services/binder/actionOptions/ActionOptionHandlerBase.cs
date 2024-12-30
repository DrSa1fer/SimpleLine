using simpleline.models.options;

namespace simpleline.services.binder.actionOptions;

public abstract class ActionOptionHandlerBase
{
    public abstract bool Is(ICommandOptionAttribute attribute);
    public abstract void Handle(ICommandOptionAttribute attribute, CommandOption commandOption, Data data);
}