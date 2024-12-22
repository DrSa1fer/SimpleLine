using System.Diagnostics.CodeAnalysis;

namespace simpleline.models.inputs;

public class Data(Input input)
{
    private readonly Input _input = input;

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
    
    //todo
}