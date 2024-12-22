namespace simpleline.parsers.@base;

public class CharParser : ParserBase
{
    public override object? Parse(string[] value)
    {
        return value.Length == 1 ? value[0] : throw new ArgumentException("Invalid value");
    }
}