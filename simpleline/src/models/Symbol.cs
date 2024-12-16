namespace simpleline.models;

public sealed record Symbol
{
    private readonly string _value;

    private Symbol(string value)
    {
        _value = value;
    }

    public static implicit operator string(Symbol symbol)
    {
        return symbol._value;
    }

    public static implicit operator Symbol(string symbol)
    {
        return new Symbol(symbol);
    }

    public override string ToString()
    {
        return this;
    }
}