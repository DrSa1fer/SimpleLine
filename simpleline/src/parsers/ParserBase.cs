namespace simpleline.parsers;

public abstract class ParserBase
{
    public abstract object? Parse(string value, ParseDelegate parse);
}