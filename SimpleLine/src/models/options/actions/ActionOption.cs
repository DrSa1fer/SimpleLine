namespace simpleline.models.options.actions;

internal class ActionOption(
    IReadOnlyCollection<IActionOptionAttribute> attributes,
    InitDelegate init,
    Type type) {
    public IReadOnlyCollection<IActionOptionAttribute> Attributes { get; } = attributes;
    public InitDelegate Init { get; } = init;
    public Type Type { get; } = type;
}