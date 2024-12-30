namespace simpleline.services.typizer;

public abstract class PrimitiveHandlerBase
{
    public abstract object? Bind(IEnumerable<string> values);
}