namespace simpleline.services.executor.main.binder.handlers.flags;

internal class FlagHandler {
    public bool Handle(IFlagAttribute attribute, DataInput dataInput) {
        return attribute.Aliases.Any(dataInput.Contains);
    }
}