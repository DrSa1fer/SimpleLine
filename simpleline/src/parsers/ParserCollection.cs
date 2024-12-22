using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace simpleline.parsers;

public class ParserCollection(IReadOnlyDictionary<Type, ParserBase> converters)
    : IReadOnlyDictionary<Type, ParserBase>
{
    public int Count
        => converters.Count;
    public IEnumerable<Type> Keys 
        => converters.Keys;
    public IEnumerable<ParserBase> Values 
        => converters.Values;
    
    public ParserBase this[Type type]
        => converters[type];
    
    public bool ContainsKey(Type key) 
        => converters.ContainsKey(key);
    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out ParserBase value) 
        => converters.TryGetValue(key, out value);
    
    public IEnumerator<KeyValuePair<Type, ParserBase>> GetEnumerator() 
        => converters.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() 
        => GetEnumerator();
}