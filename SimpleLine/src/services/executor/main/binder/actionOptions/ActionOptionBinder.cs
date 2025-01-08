using simpleline.models.options.actions;
using simpleline.services.executor.main.binder.actionOptions.arguments;
using simpleline.services.executor.main.binder.actionOptions.flags;
using simpleline.services.executor.main.binder.actionOptions.parameters;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.actionOptions;

internal class ActionOptionBinder(TypizerBase typizer) : ActionOptionBinderBase {
    private readonly ActionOptionHandlerBase[] _handlers = [
        new ActionParameterHandler(typizer),
        new ActionArgumentHandler(typizer),
        new ActionFlagHandler()
    ];

    protected override void OnBind(IEnumerable<ActionOption> options, Data data) {
        foreach (var option in options)
        foreach (var attribute in option.Attributes) {
            _handlers
                .First(handler => handler.Is(attribute))
                .Handle(attribute, option, data);
        }
    }
}