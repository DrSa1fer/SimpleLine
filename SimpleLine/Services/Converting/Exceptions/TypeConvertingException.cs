using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Services.Converting.Exceptions
{
    internal class TypeConvertingException : SimpleLineException
    {
        internal TypeConvertingException(Type type, string input, Exception? innerException = null)
            : base($"Some wrong with converting an input {input} to {type}", innerException)
        {
        }

        internal TypeConvertingException(Type type, IEnumerable<string> input, Exception? innerException = null)
            : base($"Some wrong with converting an input {string.Join(" ", input)} to {type}", innerException)
        {
        }
    }
}