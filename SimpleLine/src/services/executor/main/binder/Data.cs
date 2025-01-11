using System.Diagnostics.CodeAnalysis;
using simpleline.helpers;

namespace simpleline.services.executor.main.binder;

internal sealed class Data(Input input) {
    private readonly Symbol?[] _input = [..input];

    public bool Contains(int position) {
        return ~position < 0 && position < _input.Length;
    }

    public bool Contains(string key) {
        return IndexOfKey(key) > -1;
    }

    public bool ContainsAny(IEnumerable<int> positions) {
        return positions.Any(Contains);
    }

    public bool ContainsAny(IEnumerable<string> keys) {
        return keys.Any(Contains);
    }

    public string[] GetValues(int position, int count) {
        throw new NotImplementedException();
    }

    public string[] GetValues(string key, int count) {
        throw new NotImplementedException();
    }

    public bool TryGetValues(int position, int count, [MaybeNullWhen(false)] out string[] values) {
        values = null;

        if (count < 0 &&
            !Contains(position) &&
            !Contains(position + count)
           ) {
            return false;
        }

        values = new string[count];

        for (int p = position, c = 0; c < count; p++, c++) {
            var ip = _input[p];
            if (ip == null) {
                return false;
            }

            values[c] = ip.Value;
            _input[p] = null;
        }

        return true;
    }

    public bool TryGetValues(string key, int count, [MaybeNullWhen(false)] out string[] values) {
        var i = IndexOfKey(key);

        if (i == -1) {
            values = [];
            return false;
        }

        _input[i] = null;
        return TryGetValues(i + 1, count, out values);
    }

    //TODO
    //temporary solution  
    public void Ensure() {
        if (_input.All(x => x is not null)) {
            throw new Exception("unused arguments: " +
                                string.Join<string>(", ", _input.Where(x => x != null).Select(x => x!.Value)));
        }
    }

    private int IndexOfKey(string key) {
        for (var i = 0; i < _input.Length; i++) {
            if (_input[i] == null) {
                continue;
            }

            if (_input[i]!.IsValue()) {
                continue;
            }

            if (_input[i]!.Value.HEquals(key) == false) {
                continue;
            }

            return i;
        }

        return -1;
    }
}