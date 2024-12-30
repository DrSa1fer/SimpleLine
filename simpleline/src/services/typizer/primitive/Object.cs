namespace simpleline.services.typizer.primitive;

internal class Object : Primitive
{
    public override object? Bind(IEnumerable<string> values)
    {
        return new object();
    }
}