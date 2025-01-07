namespace simpleline.services;

internal sealed class Symbol
{
    public string Value { get; }
    private readonly Type _type;
    
    private Symbol(Type type, string value)
    {
        _type = type;
        Value = value;
    }
    
    public static Symbol CreateKey(string value) => new(Type.Key, value);
    public static Symbol CreateValue(string value) => new(Type.Value, value);

    public bool IsKey() => _type == Type.Key;
    public bool IsValue() => _type == Type.Value;
    
    private enum Type { Key, Value }
}