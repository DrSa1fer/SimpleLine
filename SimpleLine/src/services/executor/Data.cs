using System.Diagnostics.CodeAnalysis;
using simpleline.helpers;

namespace simpleline.services.executor;

internal sealed class Data(string[] input)
{
    private readonly string?[] _input = input;

    public bool TryGetValues(string key, int count, [MaybeNullWhen(false)] out string[] values)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        ArgumentException.ThrowIfNullOrEmpty(key);

        values = [];

        if (count > _input.Length)
            return false;

        var position = -1;

        for (var i = 0; i < _input.Length; i++)
        {
            if (_input[i].Compare(key) != 0)
                continue;

            if (_input[i] == null)
                return false;

            position = i;
            break;
        }

        return position != -1 && TryGetValues(position, count, out values);
    }

    public bool TryGetValues(int position, int count, [MaybeNullWhen(false)] out string[] values)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(position);
        ArgumentOutOfRangeException.ThrowIfNegative(count);

        values = new string[count];

        for (int i = position, j = 0; i < _input.Length && j < values.Length; i++, j++)
        {
            if (_input[i] == null)
                return false;

            values[j] = _input[i] ?? throw new Exception(0xDEAD.ToString());
            _input[i] = null;
        }

        return true;
    }

    //TODO
    //temporary solution  
    public bool Ensure()
    {
        return _input.All(x => x is null);
    }
}