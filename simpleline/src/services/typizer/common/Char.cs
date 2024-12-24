namespace simpleline.services.typizer.common;

public class Char : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        var value = values.Single();
        
        return value.Length == 1 ? value[0] : throw new ArgumentException("Invalid value");
    }
}