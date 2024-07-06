namespace SimpleLineLibrary.Services.CommandParsing.Activation.Exceptions
{
    internal class AbstractTypeException : Exception
    {
        public AbstractTypeException(Type type) 
            : base($"Type \"{type}\" must be not abstract")
        {
        }
    }
}
