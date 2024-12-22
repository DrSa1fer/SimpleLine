namespace simpleline.parsers.@base;

public class BoolParser : ParserBase
{
    public override object? Parse(string[] value)
    {
        return value.Single() switch
        {
            "true" or "yes" or "t" or "y" or "1" or "+" => true,
            "false" or "no" or "f" or "n" or "0" or "-" => false,
            _ => throw new Exception()
        };
    }
}