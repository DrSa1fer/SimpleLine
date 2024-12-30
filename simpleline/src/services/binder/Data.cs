using System.Diagnostics.CodeAnalysis;
using simpleline.models;
using simpleline.services.typizer;

namespace simpleline.services.binder;

internal class Data(Input input)
{
    public bool TryGetValue(string key, int valueCount, [MaybeNullWhen(false)] out string[] symbols)
    {
        symbols = new string[valueCount + 1];
        
        return true;
    }

    public bool TryGetValue(int position, int valueCount, [MaybeNullWhen(false)] out string[] symbols)
    {
        symbols = new string[valueCount + 1];


        return true;
    }
}