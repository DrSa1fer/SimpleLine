using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Services.Execution.Converting.Exceptions;

namespace SimpleLineLibrary.Services.Execution.Converting
{
    internal class Converter
    {
        private readonly IReadOnlyDictionary<Type, Func<string, object?>> _types;

        public Converter(IReadOnlyDictionary<Type, Func<string, object?>> types)
        {
            _types = types;
        }

        public object? ConvertType(Type type, string arg)
        {
            if (!_types.ContainsKey(type) && !type.IsEnum)
            {
                throw new NotSupportedTypeException(type.Name);
            }

            try
            {
                if (type.IsEnum && !_types.ContainsKey(type))
                {
                    var name = Enum.GetNames(type)
                        .FirstOrDefault(x => x.IsEqualsToken(arg));

                    return name == null
                        ? Enum.Parse(type, arg)
                        : Enum.Parse(type, name);
                }

                return _types[type]?.Invoke(arg.Trim());
            }
            catch (Exception e)
            {
                throw new TypeConvertingException(type.Name, e);
            }
        }

        public object? ConvertCollection(Type type, IEnumerable<string> args)
        {
            if (!type.IsArray)
            {
                throw new IsNotArrayException();
            }
            if (type.GetArrayRank() > 1)
            {
                throw new InvalidRankException();
            }

            var valueType = type.GetElementType()!;

            var values = args.ToArray();
            var arr = (Array)Activator.CreateInstance(type, values.Length)!;

            for (int i = 0; i < arr.Length; i++)
            {
                var value = ConvertType(valueType, values[i]);
                arr.SetValue(value, i);
            }

            return arr;
        }
    }
}