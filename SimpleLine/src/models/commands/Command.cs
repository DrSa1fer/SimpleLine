using simpleline.models.options;
using Action = simpleline.models.actions.Action;

namespace simpleline.models.commands;

internal class Command(
    IReadOnlyCollection<ICommandAttribute> attributes,
    IReadOnlyCollection<Action> actions,
    IReadOnlyCollection<Option> options) {
    public IReadOnlyCollection<ICommandAttribute> Attributes { get; } = attributes;

    public IReadOnlyCollection<Action> Actions { get; } = actions;
    public IReadOnlyCollection<Option> Options { get; } = options;
}