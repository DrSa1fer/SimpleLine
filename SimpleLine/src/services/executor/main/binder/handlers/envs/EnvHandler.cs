using simpleline.models.options;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.handlers.envs;

internal class EnvHandler(TypizerBase typizer) {
    public void Handle(IEnvAttribute attribute, Option option, Data data) {
        var value = Environment.GetEnvironmentVariable(attribute.Variable, attribute.Target) ?? "";
        option.Set(typizer.Typize(option.Type, [value]));
    }
}