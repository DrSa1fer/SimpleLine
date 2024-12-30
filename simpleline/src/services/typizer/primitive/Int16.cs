namespace simpleline.services.typizer.primitive;

public class Int16 : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return short.Parse(values.Single());
    }
}