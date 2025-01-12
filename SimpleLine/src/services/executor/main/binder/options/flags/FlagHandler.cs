namespace simpleline.services.executor.main.binder.options.flags;

internal class FlagHandler : OptionHandlerBase<IFlagAttribute> {
    protected override object? OnHandle(IFlagAttribute attribute, Type valueType, Data data) {
        if (valueType != typeof(bool)) {
            throw new Exception($"The value type of flag [{string.Join(" | ", attribute.Keys)}] must be bool");
        }

        return data.ContainsAny(attribute.Keys);
    }
}