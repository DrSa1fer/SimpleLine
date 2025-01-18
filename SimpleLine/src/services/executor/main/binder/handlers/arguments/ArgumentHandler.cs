using simpleline.models.options;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.handlers.arguments;

internal class ArgumentHandler(TypizerBase typizer) {
    public void Handle(IArgumentAttribute attribute, Option option, Data data) {
        if (!data.TryTakeValues(attribute.Position, attribute.Arity, out var values)) {
            throw new Exception("Invalid position");
        }

        option.Set(typizer.Typize(option.Type, values));
    }
}