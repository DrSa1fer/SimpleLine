namespace simpleline.services.typizer.primitive;

public class Double : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return double.Parse(values.Single());
    }
}