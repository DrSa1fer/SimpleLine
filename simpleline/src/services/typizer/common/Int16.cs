namespace simpleline.services.typizer.common;

public class Int16 : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return short.Parse(values.Single());
    }
}