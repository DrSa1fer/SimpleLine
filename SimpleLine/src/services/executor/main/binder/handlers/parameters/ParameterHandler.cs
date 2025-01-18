using simpleline.models.options;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.handlers.parameters;

internal class ParameterHandler(TypizerBase typizer) {
    public void Handle(IParameterAttribute attribute, Option option, Data data) {
        foreach (var alias in attribute.Aliases) {
            if (!data.TryTakeValues(alias, attribute.Arity, out var values)) {
                continue;
            }

            option.Set(typizer.Typize(option.Type, values));
        }

        throw new Exception("Key not found");
    }
}