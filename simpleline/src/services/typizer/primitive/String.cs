namespace simpleline.services.typizer.primitive;

public class String : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return values.Single();
    }
}