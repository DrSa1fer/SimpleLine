namespace SimpleLineLibrary.Services.Execution.Converting.Exceptions
{
    internal class TypeConvertException : Exception
    {
        public TypeConvertException(Type type, string input, Exception? innerException = null)
            : base($"Some wrong with converting an input {input} to {type}", innerException)
        {
        }

        public TypeConvertException(Type type, IEnumerable<string> input, Exception? innerException = null)
            : base($"Some wrong with converting an input {string.Join(" ", input)} to {type}", innerException)
        {
        }
    }
}