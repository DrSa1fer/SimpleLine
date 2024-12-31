using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions.flags;

internal class CommandFlagHandler : CommandOptionHandlerBase<ICommandFlagAttribute>
{
    protected override void OnHandle(ICommandFlagAttribute attribute, CommandOption option, InputData inputData)
    {
        option.SetValue(attribute.Keys
            .Any(key => inputData.TryGetValues(key, 0, out _)));
    }
}