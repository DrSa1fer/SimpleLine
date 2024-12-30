namespace simpleline.services.typizer.primitive;

internal class Int64 : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return long.Parse(values.Single());
    }
}