namespace SimpleLineLibrary.Services.CommandParsing.Activation.Exceptions
{
    internal class NotClassException : Exception
    {
        public NotClassException(Type type)
            : base($"Type \"{type}\" must be class")
        {
        }
    }
}
