namespace simpleline.services.executor.main.binder.actionOptions.flags;

internal class ActionFlagHandler : ActionOptionHandlerBase<IActionFlagAttribute> {
    protected override object? OnHandle(IActionFlagAttribute attribute, Type valueType, Data data) {
        if (valueType != typeof(bool)) {
            throw new Exception($"The value type of flag [{string.Join(" | ", attribute.Keys)}] must be bool");
        }
        return data.ContainsAny(attribute.Keys);
    }
}