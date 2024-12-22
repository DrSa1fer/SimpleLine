namespace simpleline.parsers.@base;

public class Int16Parser : ParserBase
{
    public override object? Parse(string[] value)
    {
        return short.Parse(value.Single());
    }
}