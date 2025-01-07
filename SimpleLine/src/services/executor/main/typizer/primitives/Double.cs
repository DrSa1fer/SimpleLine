namespace simpleline.services.executor.main.typizer.primitives;

internal class Double : Primitive
{
    public override object? Bind(string value)
    {
        return double.Parse(value);
    }
}