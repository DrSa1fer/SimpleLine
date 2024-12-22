using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace simpleline.models.inputs;

public class Route(Input input) : IReadOnlyList<string>
{
    public int Count => input.Items.Length;
    
    public string this[int index] => Peek(index);
    
    public string Peek(int index) => input.Items[index].Symbol;
    public string Take(int index) => input.Items[index].Symbol;
    
    public IEnumerator<string> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}