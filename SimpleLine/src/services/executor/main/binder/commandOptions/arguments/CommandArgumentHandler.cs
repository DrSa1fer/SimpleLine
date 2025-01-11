using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.commandOptions.arguments;

internal class CommandArgumentHandler(TypizerBase typizer) : CommandOptionHandlerBase<ICommandArgumentAttribute> {
    protected override object? OnHandle(ICommandArgumentAttribute attribute, Type valueType, Data data) {
        if (!data.TryGetValues(attribute.Position, attribute.Arity, out var values)) {
            throw new Exception("Position and arity mismatch");
        }

        return typizer.Typize(valueType, values);
    }
}