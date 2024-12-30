using simpleline.models.options;
using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions;

internal abstract class CommandOptionHandlerBase
{
    public abstract bool Is(ICommandOptionAttribute attribute);
    public abstract void Handle(ICommandOptionAttribute attribute, CommandOption commandOption, Data data);
}