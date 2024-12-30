using simpleline.models.commands;

namespace simpleline.models.scopes;

internal sealed class Scope(
    IReadOnlyCollection<IScopeAttribute> attributes,
    IReadOnlyCollection<Command> actions)
{
    public IReadOnlyCollection<IScopeAttribute> Attributes { get; } = attributes;
    public IReadOnlyCollection<Command> Commands { get; } = actions;
}