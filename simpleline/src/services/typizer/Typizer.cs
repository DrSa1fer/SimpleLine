using simpleline.services.typizer.primitives;
using Boolean = simpleline.services.typizer.primitives.Boolean;
using Byte = simpleline.services.typizer.primitives.Byte;
using Char = simpleline.services.typizer.primitives.Char;
using Decimal = simpleline.services.typizer.primitives.Decimal;
using Double = simpleline.services.typizer.primitives.Double;
using Int16 = simpleline.services.typizer.primitives.Int16;
using Int32 = simpleline.services.typizer.primitives.Int32;
using Int64 = simpleline.services.typizer.primitives.Int64;
using Single = simpleline.services.typizer.primitives.Single;
using String = simpleline.services.typizer.primitives.String;

namespace simpleline.services.typizer;

internal class Typizer : TypizerBase
{
    private readonly Dictionary<Type, Primitive> _primitive = new()
    {
        { typeof(byte), new Byte() },
        { typeof(short), new Int16() },
        { typeof(int), new Int32() },
        { typeof(long), new Int64() },
        { typeof(float), new Single() },
        { typeof(double), new Double() },
        { typeof(decimal), new Decimal() },
        { typeof(char), new Char() },
        { typeof(bool), new Boolean() },
        
        { typeof(string), new String() }, //Is not primitive, but is base type
    };
    public override object? Typize(Type type, IEnumerable<string> values)
    {
        if (_primitive.TryGetValue(type, out var primitive))
            return primitive.Bind(values.Single());
        
        throw new ArgumentException("Type not supported");
    }
}