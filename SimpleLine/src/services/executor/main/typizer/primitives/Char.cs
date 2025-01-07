namespace simpleline.services.executor.main.typizer.primitives;

internal class Char : Primitive
{
    public override object? Bind(string value)
    {
        return value.Length == 1 ? value[0] : throw new ArgumentException("Invalid value");
    }
}