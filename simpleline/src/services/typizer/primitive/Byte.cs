namespace simpleline.services.typizer.primitive;

internal class Byte : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return byte.Parse(values.Single());
    }
}