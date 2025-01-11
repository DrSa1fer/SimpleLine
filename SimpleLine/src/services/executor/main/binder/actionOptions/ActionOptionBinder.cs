using simpleline.models.options.actions;
using simpleline.services.executor.main.binder.actionOptions.arguments;
using simpleline.services.executor.main.binder.actionOptions.flags;
using simpleline.services.executor.main.binder.actionOptions.parameters;

namespace simpleline.services.executor.main.binder.actionOptions;

internal class ActionOptionBinder(
    ActionParameterHandler aph,
    ActionArgumentHandler aah,
    ActionFlagHandler afh
) : ActionOptionBinderBase {
    private readonly ActionOptionHandlerBase[] _handlers = [aph, aah, afh];

    protected override void OnBind(IEnumerable<ActionOption> options, Data data) {
        foreach (var option in options) {
            foreach (var attribute in option.Attributes) {
                if (_handlers.FirstOrDefault(x => x.Is(attribute)) is not { } handler) {
                    continue;
                }

                var value = handler.Handle(attribute, option.Type, data);
                option.Init(value);
            }
        }
    }
}