namespace simpleline.parsers.@base;

public class ByteParser : ParserBase
{
    public override object? Parse(string value, ParseDelegate parse)
    {
        return byte.Parse(value);
    }
}