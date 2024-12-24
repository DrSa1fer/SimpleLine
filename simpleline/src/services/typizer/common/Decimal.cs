namespace simpleline.services.typizer.common;

public class Decimal : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return decimal.Parse(values.Single());
    }
}