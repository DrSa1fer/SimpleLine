namespace simpleline.services.typizer.primitive;

public class Int64 : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return long.Parse(values.Single());
    }
}