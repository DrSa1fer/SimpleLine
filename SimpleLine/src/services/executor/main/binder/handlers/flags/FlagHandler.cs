namespace simpleline.services.executor.main.binder.handlers.flags;

internal class FlagHandler {
    public object? Handle(IFlagAttribute attribute, Type valueType, Data data) {
        if (valueType != typeof(bool)) {
            throw new Exception($"The value type of flag [{string.Join(" | ", attribute.Keys)}] must be bool");
        }

        return data.ContainsAny(attribute.Keys);
    }
}