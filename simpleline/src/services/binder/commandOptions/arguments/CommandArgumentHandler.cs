using simpleline.models.options;

namespace simpleline.services.binder.commandOptions.arguments;

public class CommandArgumentHandler : CommandOptionHandlerBaseT<ICommandArgumentAttribute>
{
    protected override void OnHandle(ICommandArgumentAttribute attribute, CommandOption commandOption, Data data)
    {
        if (data.TryGetValue(attribute.Position, 0, out var values))
        {
            return;
        }

        if (commandOption.IsRequired)
        {
            
        }
    }
}