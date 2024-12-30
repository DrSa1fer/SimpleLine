namespace simpleline.services.typizer.primitive;

internal class Int16 : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return short.Parse(values.Single());
    }
}