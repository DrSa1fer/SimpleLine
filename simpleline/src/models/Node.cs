using System.Reflection;

namespace simpleline.models;

public class Node(Symbol symbol)
{
    public Symbol            Symbol  { get; } = symbol;
    public ICollection<Node> Next    { get; } = new List<Node>();
    
    public Type?             Type    { get; set; }
}