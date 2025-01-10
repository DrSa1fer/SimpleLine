using simpleline.models.options.commands;
using simpleline.services.executor.main.binder.commandOptions.arguments;
using simpleline.services.executor.main.binder.commandOptions.flags;
using simpleline.services.executor.main.binder.commandOptions.parameters;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.commandOptions;

internal class CommandOptionBinder(
    CommandParameterHandler cph,
    CommandArgumentHandler cah,
    CommandFlagHandler cfh
) : CommandOptionBinderBase {
    private readonly CommandOptionHandlerBase[] _handlers = [cph, cah, cfh];

    protected override void OnBind(IEnumerable<CommandOption> options, Data data) {
        foreach (var option in options)
        foreach (var attribute in option.Attributes) {
            _handlers
                .First(handler => handler.Is(attribute))
                .Handle(attribute, option, data);
        }
    }
}