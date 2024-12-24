using simpleline.models.attributes;

namespace simpleline.models;

public class CommandOption(
    AttributeCollection<IOptionAttribute> attributes,
    CommandOption.GetDelegate get,
    CommandOption.SetDelegate set,
    Type type,
    bool isRequired,
    bool hasDefaultValue,
    object? defaultValue)
{
    public delegate object? GetDelegate();

    public delegate void SetDelegate(object? value);

    public AttributeCollection<IOptionAttribute> Attributes { get; } = attributes;

    public GetDelegate GetValue { get; } = get;
    public SetDelegate SetValue { get; } = set;

    public Type Type { get; } = type;
    public bool IsRequired { get; } = isRequired;

    public bool HasDefaultValue { get; } = hasDefaultValue;
    public object? DefaultValue { get; } = defaultValue;
}