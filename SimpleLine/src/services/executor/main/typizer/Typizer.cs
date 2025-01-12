using simpleline.exmodels.typizer;
using simpleline.services.executor.main.typizer.primitives;
using Boolean = simpleline.services.executor.main.typizer.primitives.Boolean;
using Byte = simpleline.services.executor.main.typizer.primitives.Byte;
using Char = simpleline.services.executor.main.typizer.primitives.Char;
using Decimal = simpleline.services.executor.main.typizer.primitives.Decimal;
using Double = simpleline.services.executor.main.typizer.primitives.Double;
using Int16 = simpleline.services.executor.main.typizer.primitives.Int16;
using Int32 = simpleline.services.executor.main.typizer.primitives.Int32;
using Int64 = simpleline.services.executor.main.typizer.primitives.Int64;
using SByte = simpleline.services.executor.main.typizer.primitives.SByte;
using Single = simpleline.services.executor.main.typizer.primitives.Single;
using String = simpleline.services.executor.main.typizer.primitives.String;

namespace simpleline.services.executor.main.typizer;

internal class Typizer(CustomTypizerCollection collection) : TypizerBase {
    private readonly Dictionary<Type, Func<IEnumerable<string>, object?>> _custom = collection.Typizers;
    private readonly Dictionary<Type, Func<string, object?>> _primitive = new() {
        {
            typeof(sbyte),
            SByte.Bind
        }, {
            typeof(short),
            Int16.Bind
        }, {
            typeof(int),
            Int32.Bind
        }, {
            typeof(long),
            Int64.Bind
        }, {
            typeof(byte),
            Byte.Bind
        }, {
            typeof(ushort),
            Uint16.Bind
        }, {
            typeof(uint),
            Uint32.Bind
        }, {
            typeof(ulong),
            Uint64.Bind
        }, {
            typeof(float),
            Single.Bind
        }, {
            typeof(double),
            Double.Bind
        }, {
            typeof(decimal),
            Decimal.Bind
        }, {
            typeof(char),
            Char.Bind
        }, {
            typeof(bool),
            Boolean.Bind
        }, {
            typeof(string),
            String.Bind
        }
    };

    protected override object? OnTypize(Type type, IEnumerable<string> values) {
        if (_custom.TryGetValue(type, out var custom)) {
            return custom(values);
        }

        if (_primitive.TryGetValue(type, out var primitive)) {
            return primitive(values.Single());
        }

        if (_custom.Keys.FirstOrDefault(x => x.IsAssignableTo(type)) is { } customKey) {
            return _custom[customKey](values);
        }

        if (_primitive.Keys.FirstOrDefault(x => x.IsAssignableTo(type)) is { } primitiveKey) {
            return _primitive[primitiveKey](values.Single());
        }

        throw new NotSupportedException($"Type: [{type}] not supported");
    }
}