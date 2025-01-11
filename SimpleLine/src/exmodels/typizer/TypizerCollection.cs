using System.Collections.ObjectModel;

namespace simpleline.exmodels.typizer;

public sealed class TypizerCollection {
    internal ReadOnlyDictionary<Type, Func<IEnumerable<string>, object?>> Typizers => _typizers.AsReadOnly();
    private readonly Dictionary<Type, Func<IEnumerable<string>, object?>> _typizers = new();
    
    public void AddTypizer<T>(TypizerBase<T> typizer) {
        _typizers[typeof(T)] = e => typizer.Typize(e);
    }
    
    public void RemoveTypizer<T>() {
        _typizers.Remove(typeof(T));
    }
}