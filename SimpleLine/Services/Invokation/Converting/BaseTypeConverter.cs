namespace SimpleLineLibrary.Services.Invokation.Converting
{
    internal abstract class BaseTypeConverter
    {
        public Type ConvertType { get; }
        public BaseTypeConverter(Type type) => ConvertType = type;
        public abstract object? Convert(string input); 
    }
}
