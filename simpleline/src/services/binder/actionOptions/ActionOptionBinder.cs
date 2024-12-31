using simpleline.services.binder.actionOptions.arguments;
using simpleline.services.binder.actionOptions.parameters;
using simpleline.services.binder.actionOptions.flags;
using simpleline.models.options.actions;
using System.Collections.Immutable;
using simpleline.services.typizer;

namespace simpleline.services.binder.actionOptions;

internal class ActionOptionBinder(TypizerBase typizer) : ActionOptionBinderBase
{
    private readonly ImmutableArray<ActionOptionHandlerBase> _handlers =
    [
        new ActionParameterHandler(typizer),
        new ActionArgumentHandler(typizer),
        new ActionFlagHandler()
    ];

    public override void Bind(IEnumerable<ActionOption> options, InputData data)
    {
        foreach (var option in options)
        foreach (var attribute in option.Attributes)
            _handlers
                .First(handler => handler.Is(attribute))
                .Handle(attribute, option, data);
    }
}