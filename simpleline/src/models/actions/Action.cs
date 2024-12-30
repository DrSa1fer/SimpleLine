using simpleline.models.options;

namespace simpleline.models.actions;

public class Action(
    IEnumerable<IActionAttribute> attributes,
    ActionOption[] options,
    Type returnType,
    Action.InvokeDelegate invoke)
{
    public delegate object? InvokeDelegate(object?[] arguments);

    public AttributeCollection<IActionAttribute> Attributes { get; } = new(attributes);

    public InvokeDelegate Invoke { get; } = invoke;
    public ActionOption[] Options { get; } = options;

    public Type ReturnType { get; } = returnType;
}