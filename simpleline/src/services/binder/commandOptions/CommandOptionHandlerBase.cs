using simpleline.models.options;

namespace simpleline.services.binder.commandOptions;

public abstract class CommandOptionHandlerBase
{
    public abstract bool Is(ICommandOptionAttribute attribute);
    public abstract void Handle(ICommandOptionAttribute attribute, CommandOption commandOption, Data data);
}