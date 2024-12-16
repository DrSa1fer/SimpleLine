namespace simpleline.models.commands;

public class Action(
    IEnumerable<IActionAttribute> attributes,
    ActionOption[] options,
    Type returnType,
    Action.InvokeDelegate invoke)
{
    public delegate object? InvokeDelegate(object?[]? args);

    public IEnumerable<IActionAttribute> Attributes { get; } = attributes;

    public ActionOption[] Options { get; } = options;
    public Type ReturnType { get; } = returnType;

    public InvokeDelegate Invoke { get; } = invoke;
}