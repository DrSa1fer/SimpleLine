namespace SimpleLineLibrary.Services.CommandParsing.Activation.Exceptions
{
    internal class GenericTypeException : Exception
    {
        public GenericTypeException(Type type)
            : base($"Type \"{type}\" must be not generic")
        {
        }
    }
}
