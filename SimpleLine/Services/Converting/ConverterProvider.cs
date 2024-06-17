using SimpleLineLibrary.Services.Converting.Exceptions;
using System.Collections;

namespace SimpleLineLibrary.Services.Converting
{
    internal class ConverterProvider
    {
        private readonly Dictionary<Type, Func<string, object?>> _types;

        public ConverterProvider()
        {
            _types = new();
        }

        public bool IsSupported(Type type)
        {
            return _types.ContainsKey(type) || type.IsArray;
        }
        public void ThrowIfNotSupported(Type type)
        {
            if (!IsSupported(type))
            {
                throw new SimpleLineLibrary
                    .Exceptions
                    .ArgumentException($"{type.Name} is not supported");
            }
        }

        public void RegisterTypeConverter<T>(Func<string, T> func)
        {
            var wrapper = new Func<string, object?>(input => func(input));

            _types.Add(typeof(T), wrapper);            
        }

        public object? ConvertEnumerable(Type type, IEnumerable<string> args)
        {
            ThrowIfNotSupported(type);

            try
            {
                if (type.IsArray)
                {
                    if (type.GetArrayRank() > 1)
                    {
                        throw new
                            SimpleLineLibrary
                            .Exceptions
                            .ArgumentException("Array rank cant be more than 1 ");
                    }

                    var valueType = type.GetElementType()!;
                    var values = args.ToArray();

                    var arr = (object?[])Activator.CreateInstance(type, values.Length)!;

                    for (int i = 0; i < arr.Length; i++)
                    {
                        var value = values[i];

                        arr[i] = ConvertType(valueType, value);
                    }

                    return arr;
                }

                throw new
                       SimpleLineLibrary
                       .Exceptions
                       .ArgumentException("Not implemented collection converting");
            }
            catch(Exception ex)
            {
                throw new TypeConvertingException(type, args, ex);
            }
        }

        public object? ConvertType(Type type, string arg)
        {
            ThrowIfNotSupported(type);

            try
            {                
                return _types[type]?.Invoke(arg);
            }
            catch(Exception ex)
            {
                throw new TypeConvertingException(type, arg, ex);
            }
        }
    }
}
