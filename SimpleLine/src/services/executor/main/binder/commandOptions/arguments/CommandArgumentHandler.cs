using simpleline.models.options.commands;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.commandOptions.arguments;

internal class CommandArgumentHandler(TypizerBase typizer) : CommandOptionHandlerBase<ICommandArgumentAttribute>
{
    protected override void OnHandle(ICommandArgumentAttribute attribute, CommandOption option, Data data)
    {
        if (!data.TryGetValues(attribute.Position, 1, out var values))
            throw new Exception("Key not found");

        option.Init(typizer.Typize(option.Type, values));
    }
}