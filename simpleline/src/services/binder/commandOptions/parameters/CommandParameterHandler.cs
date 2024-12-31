using simpleline.models.options.commands;
using simpleline.services.typizer;

namespace simpleline.services.binder.commandOptions.parameters;

internal class CommandParameterHandler(TypizerBase typizer) : CommandOptionHandlerBase<ICommandParameterAttribute>
{
    protected override void OnHandle(ICommandParameterAttribute attribute, CommandOption option, InputData inputData)
    {
        foreach (var key in attribute.Keys)
        {
            if (!inputData.TryGetValues(key, 1, out var values)) continue;

            option.SetValue(typizer.Typize(option.Type, [values[1]]));
            return;
        }

        throw new Exception("Key not found");
    }
}