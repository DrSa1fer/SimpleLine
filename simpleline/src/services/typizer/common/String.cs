namespace simpleline.services.typizer.common;

public class String : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return values.Single();
    }
}