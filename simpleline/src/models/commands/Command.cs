using simpleline.models.options;
using Action = simpleline.models.actions.Action;

namespace simpleline.models.commands;

public class Command(
    IEnumerable<ICommandAttribute> attributes,
    IReadOnlyList<Action> actions,
    IReadOnlyList<CommandOption> options)
{
    public AttributeCollection<ICommandAttribute> Attributes { get; } = new(attributes);
    
    public IReadOnlyList<Action> Actions { get; } = actions;
    public IReadOnlyList<CommandOption> Options { get; } = options;
}