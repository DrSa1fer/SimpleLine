namespace simpleline.models.commands;

public class ActionOption(
    IEnumerable<IActionOptionAttribute> attributes,
    Type optionType,
    bool isRequired,
    bool hasDefaultValue,
    object? defaultValue)
{
    public IEnumerable<IActionOptionAttribute> Attributes { get; } = attributes;

    public Type OptionType { get; } = optionType;
    public bool IsRequired { get; } = isRequired;

    public bool HasDefaultValue { get; } = hasDefaultValue;
    public object? DefaultValue { get; } = defaultValue;
}