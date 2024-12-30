namespace simpleline.services.typizer.primitive;

internal class Decimal : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return decimal.Parse(values.Single());
    }
}