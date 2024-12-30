namespace simpleline.services.typizer.primitive;

internal class String : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return values.Single();
    }
}