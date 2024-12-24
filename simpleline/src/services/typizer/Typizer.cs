namespace simpleline.services.typizer;

public class Typizer : TypizerBase
{
    private readonly Dictionary<Type, CommonHandlerBase> _common = new()
    {
        {
            typeof(object),
            new common.Object()
        },

        {
            typeof(bool),
            new common.Boolean()
        },

        {
            typeof(byte),
            new common.Byte()
        },
        {
            typeof(short),
            new common.Int16()
        },
        {
            typeof(int),
            new common.Int32()
        },
        {
            typeof(long),
            new common.Int64()
        },

        {
            typeof(float),
            new common.Single()
        },
        {
            typeof(double),
            new common.Double()
        },
        {
            typeof(decimal),
            new common.Decimal()
        },

        {
            typeof(char),
            new common.Char()
        },
        {
            typeof(string),
            new common.String()
        },
    };
    
    public override object? Typize(Type type, IEnumerable<string> values)
    {
        return type switch
        {
            { IsPrimitive: true } 
                => _common[type].Handle(values),
            _ 
                => throw new ArgumentException("Type not supported")
        }; 
    }
}