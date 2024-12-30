namespace simpleline.services.typizer.primitive;

internal class Double : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return double.Parse(values.Single());
    }
}