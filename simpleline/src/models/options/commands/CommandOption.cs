namespace simpleline.models.options.commands;

internal class CommandOption(
    IReadOnlyCollection<ICommandOptionAttribute> attributes,
    InitDelegate init,
    Type type)
{
    public IReadOnlyCollection<ICommandOptionAttribute> Attributes { get; } = attributes;
    public InitDelegate Init { get; } = init;
    public Type Type { get; } = type;
}