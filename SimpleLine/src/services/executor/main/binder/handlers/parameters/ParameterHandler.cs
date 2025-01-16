using simpleline.models.options;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.handlers.parameters;

internal class ParameterHandler(TypizerBase typizer) : Handler<IParameterAttribute> {
    protected override void OnHandle(IParameterAttribute attribute, Option option, Data data) {
        foreach (var key in attribute.Keys) {
            if (!data.TryGetValues(key, attribute.Arity, out var values)) {
                continue;
            }

            option.Set(typizer.Typize(option.Type, values));
        }

        throw new Exception("Key not found");
    }
}