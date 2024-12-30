namespace simpleline.services.typizer.primitive;

public class Decimal : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return decimal.Parse(values.Single());
    }
}