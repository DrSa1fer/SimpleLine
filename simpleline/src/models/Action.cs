using simpleline.models.attributes;

namespace simpleline.models;

public class Action(
    AttributeCollection<IActionAttribute> attributes,
    ActionOption[] options,
    Type returnType,
    Action.InvokeDelegate invoke)
{
    public delegate object? InvokeDelegate(object?[]? args);

    public AttributeCollection<IActionAttribute> Attributes { get; } = attributes;

    public ActionOption[] Options { get; } = options;

    public Type ReturnType { get; } = returnType;

    public InvokeDelegate Invoke { get; } = invoke;
}