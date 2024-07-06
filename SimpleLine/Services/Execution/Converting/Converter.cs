using SimpleLineLibrary.Extentions;

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
                throw new NotSupportedException($"{type.Name} is not supported");
            }
            
            try
            {
                if(type.IsEnum && !_types.ContainsKey(type))
                {
                    foreach(var n in Enum.GetNames(type))
                    {
                        if(n.IsEqualsToken(arg))
                        {
                            return Enum.Parse(type, n);
                        }
                    }

                    return Enum.Parse(type, arg);
                }    

                return _types[type]?.Invoke(arg.Trim());
            }
            catch(Exception e)
            {
                throw new InvalidCastException($"Cant convert string to {type}", e);
            }
        }

        public object? ConvertCollection(Type type, IEnumerable<string> args)
        {            
            if (!type.IsArray)
            {
                throw new NotSupportedException("Supported only array collections converting");
            }

            if (type.GetArrayRank() > 1)
            {
                throw new ArgumentException("Array rank cant be more than 1 ");
            }

            var valueType = type.GetElementType()!;

            var values = args.ToArray();
            var arr = (Array)Activator.CreateInstance(type, values.Length)!;

            for (int i = 0; i < arr.Length; i++)
            {
                arr.SetValue(ConvertType(valueType, values[i]), i);
            }

            return arr;
        }
    }
}