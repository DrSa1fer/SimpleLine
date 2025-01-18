using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers.flags;

internal class FlagHandler {
    public void Handle(IFlagAttribute attribute, Option option, Data data) {
        if (option.Type != typeof(bool)) {
            throw new Exception($"The value type of flag [{string.Join(" | ", attribute.Aliases)}] must be bool");
        }

        option.Set(data.ContainsAny(attribute.Aliases));
    }
}