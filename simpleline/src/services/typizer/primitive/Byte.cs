namespace simpleline.services.typizer.primitive;

public class Byte : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return byte.Parse(values.Single());
    }
}