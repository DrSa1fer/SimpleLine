namespace simpleline.models.options;

internal class Option(
    IReadOnlyCollection<IOptionAttribute> attributes,
    InitDelegate init,
    Type type) {
    public IReadOnlyCollection<IOptionAttribute> Attributes { get; } = attributes;
    public InitDelegate Init { get; } = init;
    public Type Type { get; } = type;
}