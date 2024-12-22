namespace simpleline.parsers.@base;

public class Int32Parser : ParserBase
{
    public override object? Parse(string[] value)
    {
        return int.Parse(value.Single());
    }
}