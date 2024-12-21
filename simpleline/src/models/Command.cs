using simpleline.models.attributes;

namespace simpleline.models;

public class Command(
    AttributeCollection<ICommandAttribute> attributes,
    IEnumerable<Action> actions,
    IEnumerable<Option> options)
{
    public AttributeCollection<ICommandAttribute> Attributes { get; } = attributes;
    public IEnumerable<Action> Actions { get; } = actions;
    public IEnumerable<Option> Options { get; } = options;
}