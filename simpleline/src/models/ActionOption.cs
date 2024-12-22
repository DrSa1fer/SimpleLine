using simpleline.models.attributes;

namespace simpleline.models;

public class ActionOption(
    AttributeCollection<IActionOptionAttribute> attributes,
    Type type,
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

    public Type Type { get; } = type;
    public bool IsRequired { get; } = isRequired;

    public bool HasDefaultValue { get; } = hasDefaultValue;
    public object? DefaultValue { get; } = defaultValue;
}