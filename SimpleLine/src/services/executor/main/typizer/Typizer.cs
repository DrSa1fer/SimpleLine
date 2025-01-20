using simpleline.external;
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
            SByte.Typize
        }, {
            typeof(short),
            Int16.Typize
        }, {
            typeof(int),
            Int32.Typize
        }, {
            typeof(long),
            Int64.Typize
        }, {
            typeof(byte),
            Byte.Typize
        }, {
            typeof(ushort),
            Uint16.Typize
        }, {
            typeof(uint),
            Uint32.Typize
        }, {
            typeof(ulong),
            Uint64.Typize
        }, {
            typeof(float),
            Single.Typize
        }, {
            typeof(double),
            Double.Typize
        }, {
            typeof(decimal),
            Decimal.Typize
        }, {
            typeof(char),
            Char.Typize
        }, {
            typeof(bool),
            Boolean.Typize
        }, {
            typeof(string),
            String.Typize
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