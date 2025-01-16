using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.handlers.arguments;

internal class ArgumentHandler(TypizerBase typizer) {
    public object? Handle(IArgumentAttribute attribute, Type valueType, Data data) {
        if (!data.TryGetValues(attribute.Position, attribute.Arity, out var values)) {
            throw new Exception("Invalid position");
        }

        return typizer.Typize(valueType, values);
    }
}