namespace SimpleLineLibrary.Src.Exceptions.BinderExceptions
{
    public class ConvertException : Exception
    {
        public ConvertException(string value, string type)
            : base($"Value \"{value}\" cant convert to type \"{type}\"") { }

        public ConvertException(string value, Type type) 
            : this(value, type.Name) { }
    }
}
