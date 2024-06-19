namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class NotSupportedTypeException : Exception
    {
        public NotSupportedTypeException(Type type)
            : base(type.Name)
        {
        }
    }
}