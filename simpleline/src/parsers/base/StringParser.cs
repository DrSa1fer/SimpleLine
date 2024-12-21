namespace simpleline.parsers.@base;

public class StringParser : ParserBase
{
    public override object? Parse(string value, ParseDelegate parse)
    {
        return value;
    }
}