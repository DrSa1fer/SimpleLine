namespace simpleline.services;

/// <summary>
/// Passed in input argument that present as Key or Value
/// </summary>
internal sealed class Symbol {
    public string Value { get; }

    private readonly Type _type;

    private Symbol(Type type, string value) {
        _type = type;
        Value = value;
    }

    public static Symbol CreateKey(string value) {
        return new Symbol(Type.Key, value);
    }

    public static Symbol CreateValue(string value) {
        return new Symbol(Type.Value, value);
    }

    public bool IsKey() {
        return _type == Type.Key;
    }

    public bool IsValue() {
        return _type == Type.Value;
    }

    public override string ToString() {
        return $"Type: {_type}, Value: {Value}";
    }

    private enum Type : byte {
        Key,
        Value
    }
}