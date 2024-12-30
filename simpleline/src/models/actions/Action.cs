using simpleline.models.options;
using simpleline.models.options.actions;

namespace simpleline.models.actions;

internal class Action(
    IReadOnlyCollection<IActionAttribute> attributes,
    ActionOption[] options,
    Type returnType,
    Action.InvokeDelegate invoke)
{
    public delegate object? InvokeDelegate();

    public IReadOnlyCollection<IActionAttribute> Attributes { get; } = attributes;

    public InvokeDelegate Invoke { get; } = invoke;
    public ActionOption[] Options { get; } = options;

    public Type ReturnType { get; } = returnType;
}