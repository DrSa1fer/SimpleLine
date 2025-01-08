using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions;

internal abstract class CommandOptionHandlerBase {
    public abstract bool Is(ICommandOptionAttribute attribute);
    public abstract void Handle(ICommandOptionAttribute attribute, CommandOption option, Data data);
}