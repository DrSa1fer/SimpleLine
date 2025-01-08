using System.Diagnostics.CodeAnalysis;
using simpleline.helpers;

namespace simpleline.services.executor;

internal sealed class Data(Symbol[] symbols) {
    private readonly Symbol?[] _input = symbols;

    public bool ContainsKey(string key) {
        return IndexOfKey(key) > -1;
    }

    public bool TryGetValues(string key, int count, [MaybeNullWhen(false)] out string[] values) {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        ArgumentException.ThrowIfNullOrEmpty(key);

        var i = IndexOfKey(key);

        if (i == -1) {
            values = [];
            return false;
        }

        _input[i] = null;
        return TryGetValues(i + 1, count, out values);
    }

    public bool TryGetValues(int position, int count, [MaybeNullWhen(false)] out string[] values) {
        ArgumentOutOfRangeException.ThrowIfNegative(position);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        values = new string[count];

        for (int i = position, j = 0; i < _input.Length && j < values.Length; i++, j++) {
            if (_input[i] == null) {
                return false;
            }

            values[j] = _input[i]?.Value ?? throw new Exception(0xDEAD.ToString());
            _input[i] = null;
        }

        return true;
    }

    //TODO
    //temporary solution  
    public bool Ensure() {
        return _input.All(x => x is null);
    }

    private int IndexOfKey(string key) {
        for (var i = 0; i < _input.Length; i++) {
            if (_input[i] == null) {
                continue;
            }

            if (_input[i]!.IsValue()) {
                continue;
            }

            if (!_input[i]!.Value.HEquals(key)) {
                continue;
            }

            return i;
        }

        return -1;
    }
}