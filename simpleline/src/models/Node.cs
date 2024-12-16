using simpleline.models.commands;

namespace simpleline.models;

public class Node(Symbol symbol)
{
    public Symbol Symbol { get; } = symbol;
    public ICollection<Node> Next { get; } = new List<Node>();

    public Command? Command { get; set; }
}