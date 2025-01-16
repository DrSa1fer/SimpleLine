namespace simpleline.models.options;

internal class Option(
    IReadOnlyCollection<IOptionAttribute> attributes,
    GetDelegate get,
    SetDelegate set,
    Type type) {
    public IReadOnlyCollection<IOptionAttribute> Attributes { get; } = attributes;
    public Type Type { get; } = type;
    
    public GetDelegate Get { get; } = get;
    public SetDelegate Set { get; } = set;
}