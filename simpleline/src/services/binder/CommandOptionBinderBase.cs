using simpleline.services.binder.commandOptions;
using simpleline.models.options;

namespace simpleline.services.binder;

public abstract class CommandOptionBinderBase(params CommandOptionHandlerBase[] handlers)
{
    protected IReadOnlyList<CommandOptionHandlerBase> Handlers { get; } = handlers;
    public abstract void Bind(IEnumerable<CommandOption> options, Data data); 
}