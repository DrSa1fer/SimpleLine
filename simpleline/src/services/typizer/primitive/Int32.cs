namespace simpleline.services.typizer.primitive;

public class Int32 : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return int.Parse(values.Single());
    }
}