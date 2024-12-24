namespace simpleline.services.typizer;

public abstract class CommonHandlerBase
{
    public abstract object? Handle(IEnumerable<string> values);
}