using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using simpleline.extensions;

namespace simpleline.services;

internal sealed class Data(IEnumerable<string> input)
{
    private readonly ImmutableArray<Item> _input = [..input.Select(x => new Item(x))];

    public bool TryGetValues(string key, int count, [MaybeNullWhen(false)] out string[] values)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(count, _input.Length);
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        ArgumentException.ThrowIfNullOrEmpty(key);

        var position = -1;
        values = [];

        for (var i = 0; i < _input.Length; i++)
        {
            if (_input[i].Value.Compare(key) != 0) continue;

            if (_input[i].IsUsed) return false;

            position = i;
            break;
        }

        return position != -1 && TryGetValues(position, count, out values);
    }

    public bool TryGetValues(int position, int count, [MaybeNullWhen(false)] out string[] values)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(position + count, _input.Length);
        ArgumentOutOfRangeException.ThrowIfNegative(position);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        values = new string[count + 1];
        
        for (int i = position, j = 0; i < _input.Length && j < values.Length; i++, j++)
        {
            if (_input[i].IsUsed) 
                return false;

            values[j] = _input[i].Value;
            _input[i].IsUsed = true;
        }

        return true;
    }

    //TODO
    //temporary solution  
    public bool Ensure()
    {
        return _input.All(x => x.IsUsed);
    }

    private class Item(string value)
    {
        public string Value { get; } = value;
        public bool IsUsed { get; set; } = false;
    }
}