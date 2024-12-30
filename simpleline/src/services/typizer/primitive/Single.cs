namespace simpleline.services.typizer.primitive;

internal class Single : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return float.Parse(values.Single());
    }
}