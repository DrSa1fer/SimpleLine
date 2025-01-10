using simpleline.models.options.actions;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.actionOptions.arguments;

internal class ActionArgumentHandler(TypizerBase typizer) : ActionOptionHandlerBase<IActionArgumentAttribute> {
    protected override void OnHandle(IActionArgumentAttribute attribute, ActionOption option, Data data) {
        if (!data.TryGetValues(attribute.Position, attribute.Arity, out var values)) {
            throw new Exception("Invalid position");
        }

        option.Init(typizer.Typize(option.Type, values));
    }
}