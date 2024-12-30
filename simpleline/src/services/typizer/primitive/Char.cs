namespace simpleline.services.typizer.primitive;

public class Char : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        var value = values.Single();
        
        return value.Length == 1 ? value[0] : throw new ArgumentException("Invalid value");
    }
}