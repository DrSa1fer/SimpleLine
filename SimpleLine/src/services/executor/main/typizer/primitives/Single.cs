namespace simpleline.services.executor.main.typizer.primitives;

internal class Single : Primitive
{
    public override object? Bind(string value)
    {
        return float.Parse(value);
    }
}