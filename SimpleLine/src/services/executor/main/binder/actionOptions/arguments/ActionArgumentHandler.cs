using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.actionOptions.arguments;

internal class ActionArgumentHandler(TypizerBase typizer) : ActionOptionHandlerBase<IActionArgumentAttribute> {
    protected override object? OnHandle(IActionArgumentAttribute attribute, Type valueType, Data data) {
        if (!data.TryGetValues(attribute.Position, attribute.Arity, out var values)) {
            throw new Exception("Invalid position");
        }

        return typizer.Typize(valueType, values);
    }
}