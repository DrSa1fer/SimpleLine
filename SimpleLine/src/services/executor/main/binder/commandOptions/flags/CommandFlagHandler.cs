namespace simpleline.services.executor.main.binder.commandOptions.flags;

internal class CommandFlagHandler : CommandOptionHandlerBase<ICommandFlagAttribute> {
    protected override object OnHandle(ICommandFlagAttribute attribute, Type valueType, Data data) {
        if (valueType != typeof(bool)) {
            throw new Exception($"The value type of flag [{string.Join(" | ", attribute.Keys)}] must be bool");
        }
        return data.ContainsAny(attribute.Keys);
    }
}