using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.actionOptions.parameters;

internal class ActionParameterHandler(TypizerBase typizer) : ActionOptionHandlerBase<IActionParameterAttribute> {
    protected override object? OnHandle(IActionParameterAttribute attribute, Type valueType, Data data) {
        foreach (var key in attribute.Keys) {
            if (!data.TryGetValues(key, attribute.Arity, out var values)) {
                continue;
            }

            return typizer.Typize(valueType, values);
        }

        throw new Exception("Key not found");
    }
}