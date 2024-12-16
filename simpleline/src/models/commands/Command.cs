namespace simpleline.models.commands;

public class Command(
    IEnumerable<Action> actions,
    IEnumerable<Option> options)
{
    public IEnumerable<Action> Actions { get; } = actions;
    public IEnumerable<Option> Options { get; } = options;
}