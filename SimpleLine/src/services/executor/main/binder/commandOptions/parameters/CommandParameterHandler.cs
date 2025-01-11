using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.commandOptions.parameters;

internal class CommandParameterHandler(TypizerBase typizer) : CommandOptionHandlerBase<ICommandParameterAttribute> {
    protected override object? OnHandle(ICommandParameterAttribute attribute, Type valueType, Data data) {
        foreach (var key in attribute.Keys) {
            if (!data.TryGetValues(key, attribute.Arity, out var values)) {
                continue;
            }

            return typizer.Typize(valueType, values);
        }

        throw new Exception("Key not found");
    }
}