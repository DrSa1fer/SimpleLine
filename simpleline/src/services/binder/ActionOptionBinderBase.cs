using simpleline.services.binder.actionOptions;
using simpleline.models.options;

namespace simpleline.services.binder;

public abstract class ActionOptionBinderBase(params ActionOptionHandlerBase[] handlers)
{
    protected IReadOnlyList<ActionOptionHandlerBase> Handlers { get; } = handlers;
    public abstract void Bind(IEnumerable<ActionOption> options, Data data); 
}