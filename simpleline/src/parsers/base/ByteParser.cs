namespace simpleline.parsers.@base;

public class ByteParser : ParserBase
{
    public override object? Parse(string[] value)
    {
        return byte.Parse(value.Single());
    }
}