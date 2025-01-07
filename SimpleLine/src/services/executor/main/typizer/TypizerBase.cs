using simpleline.services.executor.main.typizer.exceptions;

namespace simpleline.services.executor.main.typizer;

internal abstract class TypizerBase
{
    public object? Typize(Type type, IEnumerable<string> values)
    {
        try
        {
            return OnTypize(type, values);
        }
        catch (Exception e)
        {
            throw new TypizeException(e);
        }
    }

    protected abstract object? OnTypize(Type type, IEnumerable<string> values);
}