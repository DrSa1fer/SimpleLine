namespace simpleline.services.executor.main.validator.handlers.range;

internal interface IRangeAttribute<out T> : IRestrictionAttribute {
    public T Max { get; }
    public T Min { get; }
}