namespace simpleline.services.typizer.common;

public class Byte : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return byte.Parse(values.Single());
    }
}