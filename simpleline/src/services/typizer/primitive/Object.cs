namespace simpleline.services.typizer.primitive;

public class Object : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return new object();
    }
}