using simpleline.models.attributes;

namespace simpleline.models;

public class ActionOption(
    AttributeCollection<IActionOptionAttribute> attributes,
    Type optionType,
    bool isRequired,
    bool hasDefaultValue,
    object? defaultValue)
{
    public delegate object? GetDelegate();

    public delegate void SetDelegate(object? value);

    private object? _value;

    public AttributeCollection<IActionOptionAttribute> Attributes { get; } = attributes;
    public GetDelegate GetValue => () => _value;
    public SetDelegate SetValue => value => _value = value;

    public Type OptionType { get; } = optionType;
    public bool IsRequired { get; } = isRequired;

    public bool HasDefaultValue { get; } = hasDefaultValue;
    public object? DefaultValue { get; } = defaultValue;
}