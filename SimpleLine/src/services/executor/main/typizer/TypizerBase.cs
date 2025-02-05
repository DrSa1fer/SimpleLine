using simpleline.models.options;
using simpleline.services.executor.typizer.exceptions;

namespace simpleline.services.executor.typizer;

internal abstract class TypizerBase {
    public object? Typize(Option option, IEnumerable<string> values) {
        try {
            return OnTypize(option, values);
        }
        catch (Exception e) {
            throw new TypizeException(e);
        }
    }

    protected abstract object? OnTypize(Option option, IEnumerable<string> values);
}