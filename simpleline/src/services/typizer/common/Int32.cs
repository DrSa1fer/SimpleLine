namespace simpleline.services.typizer.common;

public class Int32 : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return int.Parse(values.Single());
    }
}