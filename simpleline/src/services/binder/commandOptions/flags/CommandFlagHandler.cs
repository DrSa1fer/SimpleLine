using simpleline.models.options;
using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions.flags;

internal class CommandFlagHandler : CommandOptionHandlerBase<ICommandFlagAttribute>
{
    protected override void OnHandle(ICommandFlagAttribute attribute, CommandOption commandOption, Data data)
    {
        if (!commandOption.Type.IsAssignableTo(typeof(bool))) throw new ArgumentException("Flag type must be bool");

        commandOption.SetValue(attribute.Keys.Any(key => data.TryGetValue(key, 0, out _)));
    }
}