namespace simpleline.services.typizer;

public abstract class TypizerBase
{
    public abstract object? Typize(Type type, IEnumerable<string> values);
}