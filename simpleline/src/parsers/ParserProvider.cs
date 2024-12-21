namespace simpleline.parsers;

public class ParserProvider
{
    private readonly ParserCollection _parsers;

    public object? Parse(Type type, string value)
    {
        return _parsers[type].Parse(value, InternalParse);
    }

    private object? InternalParse(Type t, string v)
    {
        return _parsers[t].Parse(v, InternalParse);
    }
}