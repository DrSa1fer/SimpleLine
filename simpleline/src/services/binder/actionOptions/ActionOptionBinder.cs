using simpleline.models.options;
using simpleline.models.options.actions;
using simpleline.services.binder.actionOptions.arguments;
using simpleline.services.binder.actionOptions.flags;
using simpleline.services.binder.actionOptions.parameters;
using simpleline.services.typizer;

namespace simpleline.services.binder.actionOptions;

internal class ActionOptionBinder(TypizerBase typizer) : ActionOptionBinderBase(
    typizer,
    handlers:
    [
        new ActionOptionParameterHandler(),
        new ActionOptionArgumentHandler(),
        new ActionOptionFlagHandler()
    ]
)
{
    public override void Bind(IEnumerable<ActionOption> options, Data data)
    {
        throw new NotImplementedException();
    }
}