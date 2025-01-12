using simpleline.models.options;

namespace simpleline.models.actions;

internal class Action(
    IReadOnlyCollection<IActionAttribute> attributes,
    IReadOnlyCollection<Option> options,
    InvokeDelegate invoke) {
    public IReadOnlyCollection<IActionAttribute> Attributes { get; } = attributes;
    public IReadOnlyCollection<Option> Options { get; } = options;
    public InvokeDelegate Invoke { get; } = invoke;
}