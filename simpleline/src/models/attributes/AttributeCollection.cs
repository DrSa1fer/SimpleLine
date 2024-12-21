using System.Collections;

namespace simpleline.models.attributes;

public sealed class AttributeCollection<T>(IEnumerable<T> attributes)
    : IReadOnlyCollection<T> where T : IAttribute
{
    private readonly T[] _attributes = attributes.ToArray();

    public T[] this[Range range]
        => _attributes[range];

    public T this[int index]
        => _attributes[index];

    public int Count
        => _attributes.Length;

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        return ((IEnumerable<T>)_attributes).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_attributes).GetEnumerator();
    }
}