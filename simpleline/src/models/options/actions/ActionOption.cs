namespace simpleline.models.options.actions;

internal class ActionOption(
    IReadOnlyCollection<IActionOptionAttribute> attributes,
    Type type,
    bool isRequired,
    bool hasDefaultValue,
    object? defaultValue)
{
    public delegate object? GetDelegate();

    public delegate void SetDelegate(object? value);

    private bool _isInit;
    private object? _value;

    public IReadOnlyCollection<IActionOptionAttribute> Attributes { get; } = attributes;

    public GetDelegate GetValue => () =>
    {
        if (_isInit)
            return _value;

        if (hasDefaultValue)
            return defaultValue;

        throw new InvalidOperationException("ActionOption has not been initialized.");
    };

    public SetDelegate SetValue => value =>
    {
        _isInit = true;
        _value = value;
    };

    public Type Type { get; } = type;
    public bool IsRequired { get; } = isRequired;
}