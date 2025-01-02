using simpleline.models.commands;
using simpleline.models.options.actions;

namespace simpleline.models.actions;

internal class Action(
    IReadOnlyCollection<IActionAttribute> attributes,
    IReadOnlyCollection<ActionOption> options,
    InvokeDelegate invoke)
{
    public IReadOnlyCollection<IActionAttribute> Attributes { get; } = attributes;
    public IReadOnlyCollection<ActionOption> Options { get; } = options;
    public InvokeDelegate Invoke { get; } = invoke;
}