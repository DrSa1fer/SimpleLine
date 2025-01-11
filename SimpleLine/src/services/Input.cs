using System.Collections;

namespace simpleline.services;

/// <summary>
/// Implementation of List`Symbol. Present user input  
/// </summary>
/// <param name="input"></param>
internal class Input(IEnumerable<Symbol> input) : IList<Symbol> {
    bool ICollection<Symbol>.IsReadOnly => false;
    public int Count => _input.Count;

    private readonly List<Symbol> _input = [..input];

    public IEnumerator<Symbol> GetEnumerator() {
        return _input.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return _input.GetEnumerator();
    }

    public void Add(Symbol item) {
        _input.Add(item);
    }

    public void Clear() {
        _input.Clear();
    }

    public bool Contains(Symbol item) {
        return _input.Contains(item);
    }

    public void CopyTo(Symbol[] array, int arrayIndex) {
        _input.CopyTo(array, arrayIndex);
    }

    public bool Remove(Symbol item) {
        return _input.Remove(item);
    }

    public int IndexOf(Symbol item) {
        return _input.IndexOf(item);
    }

    public void Insert(int index, Symbol item) {
        _input.Insert(index, item);
    }

    public void RemoveAt(int index) {
        _input.RemoveAt(index);
    }

    public Symbol this[int index] {
        get => _input[index];
        set => _input[index] = value;
    }
}