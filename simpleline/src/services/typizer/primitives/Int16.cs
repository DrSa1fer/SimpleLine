namespace simpleline.services.typizer.primitives;

internal class Int16 : Primitive
{
    public override object? Bind(string value)
    {
        return short.Parse(value);
    }
}