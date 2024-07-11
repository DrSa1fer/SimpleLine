namespace SimpleLineLibrary.Services.Execution.Converting.Exceptions
{
    internal class NotSupportedTypeException : Exception
    {
        public NotSupportedTypeException(string typeName)
            : base($"{typeName} is not supported")
        {
        }
    }
}
