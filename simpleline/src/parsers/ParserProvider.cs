using simpleline.parsers.@base;

namespace simpleline.parsers;

public class ParserProvider
{
    private readonly ParserCollection _parsers = new(new Dictionary<Type, ParserBase>
    {
        {
            typeof(bool),
            new BoolParser()
        },
        {
            typeof(byte),
            new ByteParser()
        },
        {
            typeof(short),
            new Int16Parser()
        },
        {
            typeof(int),
            new Int32Parser()
        },
        {
            typeof(long),
            new Int64Parser()
        },
        {
            typeof(string),
            new StringParser()
        },
        {
            typeof(char),
            new CharParser()
        },
    });

    public object? Parse(Type type, string[] values)
    {
        return _parsers[type].Parse(values);
    }
}