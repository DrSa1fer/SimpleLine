using System.Collections;

namespace simpleline.models.inputs;

public class RouteInput(Input input) : IEnumerator<Symbol>
{
    private const int DefaultSeek = -1;

    private int _seek = DefaultSeek;

    public IEnumerable<Symbol> Route => _seek != DefaultSeek
        ? input.Items[..(_seek + 1)].Select(x => x.Symbol)
        : [];

    public Symbol Current => input.Items[_seek].Symbol;
    object? IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_seek != DefaultSeek) input.Items[_seek].IsRoute = true;

        return ++_seek < input.Items.Length;
    }

    public void Reset()
    {
        foreach (var t in input.Items) t.IsRoute = false;

        _seek = DefaultSeek;
    }


    public void Dispose()
    {
        // TODO release managed resources here
    }
}