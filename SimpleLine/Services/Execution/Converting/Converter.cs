﻿using SimpleLineLibrary.Services.Execution.Converting.Exceptions;

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
            ThrowIfNotSupported(type);

            return _types[type]?.Invoke(arg);
        }
        public object? ConvertCollection(Type type, IEnumerable<string> args)
        {
            ThrowIfNotSupported(type);

            if (type.IsArray)
            {
                if (type.GetArrayRank() > 1)
                {
                    throw new ArgumentException("Array rank cant be more than 1 ");
                }

                var valueType = type.GetElementType()!;
                var values = args.ToArray();

                var arr = (Array)Activator.CreateInstance(type, values.Length)!;

                for (int i = 0; i < arr.Length; i++)
                {
                    var value = values[i];

                    arr.SetValue(ConvertType(valueType, value), i);
                }

                return arr;
            }

            throw new CollectionConvertException();
        }

        private void ThrowIfNotSupported(Type type)
        {
            if (!_types.ContainsKey(type) && !type.IsArray)
            {
                throw new ArgumentException($"{type.Name} is not supported");
            }
        }
    }
}