namespace simpleline.models.commands;

public class Command(
    IEnumerable<ICommandAttribute> attributes,
    IEnumerable<Action> actions,
    IEnumerable<Option> options,
    Lazy<object?> instance)
{
    public IEnumerable<ICommandAttribute> Attributes { get; } = attributes;
    public IEnumerable<Action> Actions { get; } = actions;
    public IEnumerable<Option> Options { get; } = options;
    
    public Lazy<object?> Instance { get; } = instance;
}