namespace simpleline.services.typizer.common;

public class Object : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return new object();
    }
}