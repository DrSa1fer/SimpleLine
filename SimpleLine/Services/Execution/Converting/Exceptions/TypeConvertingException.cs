namespace SimpleLineLibrary.Services.Execution.Converting.Exceptions
{
    internal class TypeConvertingException : Exception
    {
        public TypeConvertingException(string name, Exception? e)
            : base($"Cant convert string to {name}", e)
        {
        }
    }
}
