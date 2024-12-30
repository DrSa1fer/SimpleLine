namespace simpleline.services.typizer;

internal abstract class TypizerBase
{
    public abstract object? Typize(Type type, IEnumerable<string> values);
}