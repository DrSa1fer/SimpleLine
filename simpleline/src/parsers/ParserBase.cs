namespace simpleline.parsers;

public delegate object? ParseDelegate(Type type, string[] value);
public abstract class ParserBase
{
    public abstract object? Parse(string[] value);
}