using simpleline.models.options;
using simpleline.services.binder.commandOptions;

namespace simpleline.services.binder.actionOptions.arguments;

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