using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions.flags;

internal class CommandFlagHandler : CommandOptionHandlerBase<ICommandFlagAttribute> {
    protected override void OnHandle(ICommandFlagAttribute attribute, CommandOption option, Data data) {
        option.Init(attribute.Keys
            .Any(key => data.TryGetValues(key, 0, out _)));
    }
}