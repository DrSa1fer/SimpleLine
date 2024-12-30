using simpleline.models.options;
using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions.arguments;

internal class CommandArgumentHandler : CommandOptionHandlerBase<ICommandArgumentAttribute>
{
    protected override void OnHandle(ICommandArgumentAttribute attribute, CommandOption commandOption, Data data)
    {
        if (data.TryGetValue(attribute.Position, 0, out var values)) return;

        if (commandOption.IsRequired)
        {
        }
    }
}