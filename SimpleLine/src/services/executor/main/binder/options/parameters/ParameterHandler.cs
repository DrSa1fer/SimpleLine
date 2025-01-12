using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.options.parameters;

internal class ParameterHandler(TypizerBase typizer) : OptionHandlerBase<IParameterAttribute> {
    protected override object? OnHandle(IParameterAttribute attribute, Type valueType, Data data) {
        foreach (var key in attribute.Keys) {
            if (!data.TryGetValues(key, attribute.Arity, out var values)) {
                continue;
            }

            return typizer.Typize(valueType, values);
        }

        throw new Exception("Key not found");
    }
}