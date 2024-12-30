namespace simpleline.models;

public sealed class Input(IEnumerable<string> symbols)
{
    private Symbol[] _symbols = symbols
        .Select(x => new Symbol())
        .ToArray();
    
    
}