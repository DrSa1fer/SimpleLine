namespace simpleline.services.typizer.primitive;

public class Single : PrimitiveHandlerBase
{
    public override object? Bind(IEnumerable<string> values)
    {
        return float.Parse(values.Single());
    }
}