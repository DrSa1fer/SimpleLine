namespace simpleline.models.inputs;

public sealed class Input(IEnumerable<Symbol> symbols)
{
    public Item[] Items { get; } = symbols
        .Select(symbol => new Item(symbol)).ToArray();

    public class Item(Symbol symbol)
    {
        public Symbol Symbol { get; } = symbol;
        public bool IsRoute { get; set; }
        public bool IsUsed  { get; set; }
    }
}