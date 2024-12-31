namespace simpleline.services.typizer.primitives;

internal class String : Primitive
{
    public override object? Bind(string value)
    {
        return value;
    }
}