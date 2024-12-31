using simpleline.models.options.commands;
using simpleline.services.typizer;

namespace simpleline.services.binder.commandOptions.arguments;

internal class CommandArgumentHandler(TypizerBase typizer) : CommandOptionHandlerBase<ICommandArgumentAttribute>
{
    protected override void OnHandle(ICommandArgumentAttribute attribute, CommandOption option, InputData inputData)
    {
        if (!inputData.TryGetValues(attribute.Position, 1, out var values)) throw new Exception("Key not found");

        option.SetValue(typizer.Typize(option.Type, [values[1]]));
    }
}