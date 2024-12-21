using System.Collections;

namespace simpleline.parsers;

public class ParserCollection(IDictionary<Type, ParserBase> converters)
    : IReadOnlyCollection<ParserBase>
{
    public ParserBase this[Type type]
        => converters[type];

    public int Count
        => converters.Count;

    public IEnumerator<ParserBase> GetEnumerator()
    {
        return converters.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return converters.Values.GetEnumerator();
    }
}