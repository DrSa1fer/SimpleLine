namespace simpleline.parsers.@base;

public class Int64Parser : ParserBase
{
    public override object? Parse(string value, ParseDelegate parse)
    {
        return long.Parse(value);
    }
}