namespace simpleline.models.commands;

public class Option(
    IEnumerable<IOptionAttribute> attributes,
    Type optionType,
    bool isRequired,
    bool hasDefaultValue,
    object? defaultValue,
    Option.GetValueDelegate getValue,
    Option.SetValueDelegate setValue)
{
    public delegate object? GetValueDelegate(object? obj);
    public delegate void SetValueDelegate(object? obj, object? value);

    public IEnumerable<IOptionAttribute> Attributes { get; } = attributes;

    public Type OptionType { get; } = optionType;
    public bool IsRequired { get; } = isRequired;

    public bool HasDefaultValueValue { get; } = hasDefaultValue;
    public object? DefaultValue { get; } = defaultValue;

    public GetValueDelegate GetValue { get; } = getValue;
    public SetValueDelegate SetValue { get; } = setValue;
}