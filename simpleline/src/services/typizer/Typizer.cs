using simpleline.services.typizer.primitive;
using Boolean = simpleline.services.typizer.primitive.Boolean;
using Byte = simpleline.services.typizer.primitive.Byte;
using Char = simpleline.services.typizer.primitive.Char;
using Decimal = simpleline.services.typizer.primitive.Decimal;
using Double = simpleline.services.typizer.primitive.Double;
using Int16 = simpleline.services.typizer.primitive.Int16;
using Int32 = simpleline.services.typizer.primitive.Int32;
using Int64 = simpleline.services.typizer.primitive.Int64;
using Object = simpleline.services.typizer.primitive.Object;
using Single = simpleline.services.typizer.primitive.Single;
using String = simpleline.services.typizer.primitive.String;

namespace simpleline.services.typizer;

internal class Typizer : TypizerBase
{
    private readonly Dictionary<Type, Primitive> _primitive = new()
    {
        { typeof(object), new Object() },
        { typeof(byte), new Byte() },
        { typeof(short), new Int16() },
        { typeof(int), new Int32() },
        { typeof(long), new Int64() },
        { typeof(float), new Single() },
        { typeof(double), new Double() },
        { typeof(decimal), new Decimal() },
        { typeof(bool), new Boolean() },
        { typeof(char), new Char() },
        { typeof(string), new String() }
    };

    public override object? Typize(Type type, IEnumerable<string> values)
    {
        return type switch
        {
            { IsPrimitive: true }
                => _primitive[type].Bind(values),
            _
                => throw new ArgumentException("Type not supported")
        };
    }
}