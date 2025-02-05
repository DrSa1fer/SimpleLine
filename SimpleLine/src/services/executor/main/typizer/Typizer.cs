using System.Globalization;
using simpleline.models.options;

namespace simpleline.services.executor.typizer;

internal class Typizer : TypizerBase {
    protected override object? OnTypize(Option option, IEnumerable<string> values) {
        var arr = values.ToArray();
        var type = option.Type;

        if (option.Attributes.FirstOrDefault(x => x is ITypizeAttribute) is {} attribute) {
            return null;
        }

        return arr.Length switch {
            > 1 => TypizeMultiply(type, arr),
            1 => TypizeSingle(type, arr[0]),
            _ => TypizeZero(type)
        };
    }

    private static object? TypizeZero(Type type) {
        if (type == typeof(bool)) {
            return false;
        }

        if (type == typeof(string)) {
            return string.Empty;
        }
        
        
        
        throw new Exception();
    }

    private static object? TypizeSingle(Type type, string value) {
        if (type == typeof(string)) {
            return value;
        }
        
        if (type == typeof(bool)) {
            return value switch {
                "true" or "t" or "yes" or "y" or "1" => true,
                "false" or "f" or "no" or "n" or "0" => false,
                _ => throw new Exception()
            };
        }
        
        if (type.IsEnum) {
            return Enum.Parse(type, value);
        }
        
        if (type.IsAssignableTo(typeof(IConvertible))) {
            return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }

        if (type.GetConstructor([typeof(string)]) is {} stringCtor) {
            return stringCtor.Invoke([value]);
        }
        
        throw new Exception();
    }

    private static object? TypizeMultiply(Type type, string[] values) {
        if (type.IsArray) {
            var elementType = type.GetElementType()!;
            var lArray = Array.CreateInstance(elementType, values.Length);

            for (var i = 0; i < lArray.Length; i++) {
                lArray.SetValue(TypizeSingle(elementType, values[i]), i);
            }

            return lArray;
        }


        throw new NotSupportedException("Not array collections not supported");
    }
}