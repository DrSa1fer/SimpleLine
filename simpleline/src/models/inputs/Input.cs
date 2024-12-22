namespace simpleline.models.inputs;

public sealed class Input(IEnumerable<string> symbols)
{
    public Item[] Items { get; } = symbols
        .Select(symbol => new Item(symbol)).ToArray();

    public class Item(string symbol)
    {
        public string Symbol { get; } = symbol;
        public bool IsRoute { get; set; }
        public bool IsUsed { get; set; }
    }
}