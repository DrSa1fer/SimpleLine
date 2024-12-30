namespace simpleline.services.typizer.primitive;

internal class Int32 : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return int.Parse(values.Single());
    }
}