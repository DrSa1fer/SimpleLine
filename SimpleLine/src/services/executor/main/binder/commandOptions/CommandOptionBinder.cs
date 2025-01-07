using System.Collections.Immutable;
using simpleline.models.options.commands;
using simpleline.services.executor.main.binder.commandOptions.arguments;
using simpleline.services.executor.main.binder.commandOptions.flags;
using simpleline.services.executor.main.binder.commandOptions.parameters;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.commandOptions;

internal class CommandOptionBinder(TypizerBase typizer) : CommandOptionBinderBase
{
    private readonly ImmutableArray<CommandOptionHandlerBase> _handlers =
    [
        new CommandParameterHandler(typizer),
        new CommandArgumentHandler(typizer),
        new CommandFlagHandler()
    ];

    protected override void OnBind(IEnumerable<CommandOption> options, Data data)
    {
        foreach (var option in options)
        foreach (var attribute in option.Attributes)
            _handlers
                .First(handler => handler.Is(attribute))
                .Handle(attribute, option, data);
    }
}