using simpleline.services.executor.main.typizer.primitives;
using Boolean = simpleline.services.executor.main.typizer.primitives.Boolean;
using Byte = simpleline.services.executor.main.typizer.primitives.Byte;
using Char = simpleline.services.executor.main.typizer.primitives.Char;
using Decimal = simpleline.services.executor.main.typizer.primitives.Decimal;
using Double = simpleline.services.executor.main.typizer.primitives.Double;
using Int16 = simpleline.services.executor.main.typizer.primitives.Int16;
using Int32 = simpleline.services.executor.main.typizer.primitives.Int32;
using Int64 = simpleline.services.executor.main.typizer.primitives.Int64;
using Single = simpleline.services.executor.main.typizer.primitives.Single;
using String = simpleline.services.executor.main.typizer.primitives.String;

namespace simpleline.services.executor.main.typizer;

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

        //Is not primitive, but is base type
        { typeof(string), new String() }
    };

    protected override object? OnTypize(Type type, IEnumerable<string> values)
    {
        if (_primitive.TryGetValue(type, out var primitive))
            return primitive.Bind(values.Single());

        throw new ArgumentException("Type not supported");
    }
}