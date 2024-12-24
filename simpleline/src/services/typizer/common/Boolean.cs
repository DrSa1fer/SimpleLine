namespace simpleline.services.typizer.common;

public class Boolean : CommonHandlerBase
{
    public override object? Handle(IEnumerable<string> values)
    {
        return values.Single() switch
        {
            "true" or "yes" or "t" or "y" or "1" or "+" => true,
            "false" or "no" or "f" or "n" or "0" or "-" => false,
            _ => throw new Exception()
        };
    }
}