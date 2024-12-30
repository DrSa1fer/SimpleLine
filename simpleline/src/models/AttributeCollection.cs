using System.Collections;

namespace simpleline.models;

public class AttributeCollection<T>(IEnumerable<T> enumerable) : IReadOnlyCollection<T> where T : IAttribute
{
    private readonly Dictionary<Type, T> _attributes = enumerable.ToDictionary(x => x.GetType());

    public int Count => _attributes.Count;

    public TAttr GetAttribute<TAttr>() where TAttr : T
    {
        return (TAttr)_attributes[typeof(T)];
    }

    public IEnumerable<TAttr> GetAttributes<TAttr>() where TAttr : IAttribute
    {
        return _attributes.Values.OfType<TAttr>();
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _attributes.Values.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _attributes.Values.GetEnumerator();
    }
}