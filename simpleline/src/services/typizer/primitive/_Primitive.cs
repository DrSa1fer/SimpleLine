namespace simpleline.services.typizer.primitive;

internal abstract class Primitive
{
    public abstract object? Bind(IEnumerable<string> values);
}