namespace simpleline.models.commands;

public class Command(
    IEnumerable<ICommandAttribute> attributes,
    IEnumerable<Action> actions,
    IEnumerable<Option> options)
{
    public IEnumerable<ICommandAttribute> Attributes { get; } = attributes;
    public IEnumerable<Action> Actions { get; } = actions;
    public IEnumerable<Option> Options { get; } = options;
}