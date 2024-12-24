using simpleline.models;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions.flags;

public class FlagHandler : CommandOptionHandlerBaseT<IFlagAttribute>
{
    protected override void OnHandle(IFlagAttribute attribute, CommandOption commandOption, Data data)
    {
        if (!commandOption.Type.IsAssignableTo(typeof(bool)))
        {
            throw new ArgumentException("Flag type must be bool");
        }

        commandOption.SetValue(attribute.Keys.Any(key => data.TryGetValue(key, 0, out _)));
    }
}