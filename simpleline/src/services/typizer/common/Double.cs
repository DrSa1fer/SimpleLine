namespace simpleline.services.typizer.common;

public class Double : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return double.Parse(values.Single());
    }
}