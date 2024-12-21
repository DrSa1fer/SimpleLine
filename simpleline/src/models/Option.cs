using simpleline.models.attributes;

namespace simpleline.models;

public class Option(
    AttributeCollection<IOptionAttribute> attributes,
    Option.GetDelegate get,
    Option.SetDelegate set,
    Type optionType,
    bool isRequired,
    bool hasDefaultValue,
    object? defaultValue)
{
    public delegate object? GetDelegate();

    public delegate void SetDelegate(object? value);

    public AttributeCollection<IOptionAttribute> Attributes { get; } = attributes;

    public GetDelegate GetValue { get; } = get;
    public SetDelegate SetValue { get; } = set;

    public Type OptionType { get; } = optionType;
    public bool IsRequired { get; } = isRequired;

    public bool HasDefaultValueValue { get; } = hasDefaultValue;
    public object? DefaultValue { get; } = defaultValue;
}