namespace simpleline.exmodels.typizer;

public abstract class TypizerBase<T> {
    public abstract T Typize(IEnumerable<string> values);
}