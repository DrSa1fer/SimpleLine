namespace simpleline.services.executor.main.complier.handlers.range;

internal interface IRangeAttribute<out T> : ICompliantAttribute {
    public T Max { get; }
    public T Min { get; }
}