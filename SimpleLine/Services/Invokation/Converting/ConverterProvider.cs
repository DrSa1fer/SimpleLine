using SimpleLineLibrary.Services.Invokation.Converting.Exceptions;

namespace SimpleLineLibrary.Services.Invokation.Converting
{
    internal class ConverterProvider
    {
        private readonly Dictionary<Type, BaseTypeConverter> _dict;

        public ConverterProvider()
        {
            _dict = new();
        }

        public bool IsSupported(Type type)
        {
            return _dict.ContainsKey(type);
        }
        public void ThrowIfNotSupported(Type type)
        {
            if(!IsSupported(type))
            {
                throw new NotSupportedTypeConvertingException(type);
            }
        }

        public void RegisterConverter<T>(TypeConverter<T> converter)
        {
            try
            {
                _dict.Add(converter.ConvertType, converter);
            }
            catch
            {
                throw new RegisterConverterException(converter);
            }
        }

        public object? Convert(string input, Type type)
        {
            ThrowIfNotSupported(type);

            try
            {
                return _dict[type].Convert(input);
            }
            catch
            {
                throw new TypeConvertingException(input);
            }
        }

        public T? Convert<T>(string input)
        {
            ThrowIfNotSupported(typeof(T));

            try
            {
                return (T?)_dict[typeof(T)].Convert(input);
            }
            catch
            {
                throw new TypeConvertingException(input);
            }
        }
    }
}
