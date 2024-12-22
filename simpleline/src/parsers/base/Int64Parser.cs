namespace simpleline.parsers.@base;

public class Int64Parser : ParserBase
{
    public override object? Parse(string[] value)
    {
        return long.Parse(value.Single());
    }
}