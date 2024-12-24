using simpleline.models;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions.arguments;

public class ArgumentHandler : CommandOptionHandlerBaseT<IArgumentAttribute>
{
    protected override void OnHandle(IArgumentAttribute attribute, CommandOption commandOption, Data data)
    {
        if (!data.TryGetValue(attribute.Position, 0, out var values))
        {
            return;
        }
    }
}