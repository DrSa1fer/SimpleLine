using simpleline.models.options;

namespace simpleline.services.binder.commandOptions.flags;

public class CommandFlagHandler : CommandOptionHandlerBaseT<ICommandFlagAttribute>
{
    protected override void OnHandle(ICommandFlagAttribute attribute, CommandOption commandOption, Data data)
    {
        if (!commandOption.Type.IsAssignableTo(typeof(bool)))
        {
            throw new ArgumentException("Flag type must be bool");
        }

        commandOption.SetValue(attribute.Keys.Any(key => data.TryGetValue(key, 0, out _)));
    }
}