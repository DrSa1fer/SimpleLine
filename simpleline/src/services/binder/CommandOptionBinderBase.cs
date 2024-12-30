using simpleline.services.binder.commandOptions;
using simpleline.models.options;
using simpleline.models.options.commands;

namespace simpleline.services.binder;

internal abstract class CommandOptionBinderBase(params CommandOptionHandlerBase[] handlers)
{
    protected IReadOnlyList<CommandOptionHandlerBase> Handlers { get; } = handlers;
    public abstract void Bind(IEnumerable<CommandOption> options, Data data);
}