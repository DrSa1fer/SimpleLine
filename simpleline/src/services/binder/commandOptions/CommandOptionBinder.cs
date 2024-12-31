using simpleline.services.binder.commandOptions.parameters;
using simpleline.services.binder.commandOptions.arguments;
using simpleline.services.binder.commandOptions.flags;
using simpleline.models.options.commands;
using System.Collections.Immutable;
using simpleline.services.typizer;

namespace simpleline.services.binder.commandOptions;

internal class CommandOptionBinder(TypizerBase typizer) : CommandOptionBinderBase
{
    private readonly ImmutableArray<CommandOptionHandlerBase> _handlers =
    [
        new CommandParameterHandler(typizer),
        new CommandArgumentHandler(typizer),
        new CommandFlagHandler()
    ];

    public override void Bind(IEnumerable<CommandOption> options, InputData data)
    {
        foreach (var option in options)
        foreach (var attribute in option.Attributes)
            _handlers
                .First(handler => handler.Is(attribute))
                .Handle(attribute, option, data);
    }
}