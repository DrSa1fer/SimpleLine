using System.Collections;
using System.Diagnostics.CodeAnalysis;
using simpleline.helpers;

namespace simpleline.services.executor;

internal sealed class DataInput(IEnumerable<Symbol> input) : IEnumerable<Symbol> {
    private readonly Symbol?[] _input = input.ToArray();

    public bool Contains(int position) {
        return ~position < 0 && position < _input.Length;
    }

    public bool Contains(string alias) {
        return _input.Any(x =>
            x is { IsKey: true } && 
            x.Value.HEquals(alias)
        );
    }

    public bool TryTakeKey(int position) {
        return Contains(position)
               && _input[position] != null
               && _input[position]!.IsKey;
    }
    
    public bool TryTakeKey(string alias) {
        throw new NotImplementedException();
    }

    public bool TryTakeValues(int position, int count, [MaybeNullWhen(false)] out string[] values) {
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

    public bool TryTakeValues(string alias, int count, [MaybeNullWhen(false)] out string[] values) {
        var i = IndexOfAlias(alias);

        if (i == -1) {
            values = [];
            return false;
        }

        _input[i] = null;
        return TryTakeValues(i + 1, count, out values);
    }

    //TODO
    //temporary solution  
    public void Ensure() {
        if (_input.Any(x => x is not null)) {
            throw new Exception("Unused symbols: \n" +
                                string.Join<string>(", \n",
                                    _input.Where(x => x is not null).Select(x => x!.ToString())));
        }
    }

    private int IndexOfAlias(string alias) {
        for (var i = 0; i < _input.Length; i++) {
            if (_input[i] == null) {
                continue;
            }

            if (_input[i]!.IsKey) {
                continue;
            }

            if (_input[i]!.Value.HEquals(alias) == false) {
                continue;
            }

            return i;
        }

        return -1;
    }

    public IEnumerator<Symbol> GetEnumerator() {
        return _input
            .Where(x => x is not null)
            .OfType<Symbol>()
            .GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}