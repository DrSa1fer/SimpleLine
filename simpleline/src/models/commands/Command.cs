using simpleline.models.options.commands;
using Action = simpleline.models.actions.Action;

namespace simpleline.models.commands;

internal class Command(
    IReadOnlyCollection<ICommandAttribute> attributes,
    IReadOnlyCollection<Action> actions,
    IReadOnlyCollection<CommandOption> options)
{
    public IReadOnlyCollection<ICommandAttribute> Attributes { get; } = attributes;

    public IReadOnlyCollection<Action> Actions { get; } = actions;
    public IReadOnlyCollection<CommandOption> Options { get; } = options;
}