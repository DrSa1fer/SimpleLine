namespace simpleline.services.typizer.primitives;

internal class Boolean : Primitive
{
    public override object? Bind(string value)
    {
        return value switch
        {
            "true" or "yes" or "t" or "y" or "1" or "+" => true,
            "false" or "no" or "f" or "n" or "0" or "-" => false,
            _ => throw new Exception()
        };
    }
}