namespace simpleline.services.typizer.primitives;

internal class Decimal : Primitive
{
    public override object? Bind(string value)
    {
        return decimal.Parse(value);
    }
}