using simpleline.models;
using simpleline.services.binder.commandOptions.arguments;
using simpleline.services.binder.commandOptions.flags;
using simpleline.services.binder.commandOptions.parameters;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions;

public class CommandOptionBinder : CommandOptionBinderBase
{
    private CommandOptionHandlerBase[] _handlers = [
        new ParameterHandler(),
        new ArgumentHandler(),
        new FlagHandler(),
    ];

    public override void Bind(CommandOption option, Data data)
    {
        foreach (var attr in option.Attributes)
        {
            _handlers
                .First(handler => handler.Is(attr))
                .Handle(attr, option, data);
        }
    }

}