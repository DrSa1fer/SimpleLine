namespace simpleline.services.typizer.common;

public class Single : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return float.Parse(values.Single());
    }
}