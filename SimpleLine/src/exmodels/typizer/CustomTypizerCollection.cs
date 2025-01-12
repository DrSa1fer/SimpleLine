namespace simpleline.exmodels.typizer;

public sealed class CustomTypizerCollection {
    internal Dictionary<Type, Func<IEnumerable<string>, object?>> Typizers { get; } = new();

    public void AddTypizer<T>(Func<IEnumerable<string>, T> typizer) {
        Typizers[typeof(T)] = e => typizer(e);
    }

    public void RemoveTypizer<T>() {
        Typizers.Remove(typeof(T));
    }
}