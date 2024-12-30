using simpleline.services.binder.actionOptions;
using simpleline.models.options;
using simpleline.models.options.actions;
using simpleline.services.typizer;

namespace simpleline.services.binder;

internal abstract class ActionOptionBinderBase(TypizerBase typizer, params ActionOptionHandlerBase[] handlers)
{
    protected IReadOnlyList<ActionOptionHandlerBase> Handlers { get; } = handlers;
    protected TypizerBase Typizer { get; } = typizer;
    public abstract void Bind(IEnumerable<ActionOption> options, Data data);
}