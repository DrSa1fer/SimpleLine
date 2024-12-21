namespace simpleline.parsers.@base;

public class Int16Parser : ParserBase
{
    public override object? Parse(string value, ParseDelegate parse)
    {
        return short.Parse(value);
    }
}