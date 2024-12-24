namespace simpleline.services.typizer.common;

public class Int64 : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return long.Parse(values.Single());
    }
}