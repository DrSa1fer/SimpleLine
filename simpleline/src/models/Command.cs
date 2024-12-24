using simpleline.models.attributes;

namespace simpleline.models;

public class Command(
    AttributeCollection<ICommandAttribute> attributes,
    IEnumerable<Action> actions,
    IEnumerable<CommandOption> options)
{
    public AttributeCollection<ICommandAttribute> Attributes { get; } = attributes;
    public IEnumerable<Action> Actions { get; } = actions;
    public IEnumerable<CommandOption> Options { get; } = options;
}