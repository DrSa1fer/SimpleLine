namespace SimpleLineLibrary.Services.Invokation.Converting
{
    internal class TypeConverter<T> : BaseTypeConverter
    {
        private readonly Func<string, T> _converter;

        public TypeConverter(Func<string, T> converter) : base(typeof(T))
        {
            _converter = converter;
        }

        public sealed override object? Convert(string input)
        {
            return _converter(input);
        }
    }
}
