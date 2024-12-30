using simpleline.models.options;
using simpleline.models.options.commands;
using simpleline.services.binder.commandOptions.arguments;
using simpleline.services.binder.commandOptions.flags;
using simpleline.services.binder.commandOptions.parameters;

namespace simpleline.services.binder.commandOptions;

internal class CommandOptionBinder() : CommandOptionBinderBase(
    new CommandParameterHandler(),
    new CommandArgumentHandler(),
    new CommandFlagHandler())
{
    public override void Bind(IEnumerable<CommandOption> options, Data data)
    {
        foreach (var option in options)
        foreach (var attr in option.Attributes)
            Handlers
                .First(handler => handler.Is(attr))
                .Handle(attr, option, data);
    }
}