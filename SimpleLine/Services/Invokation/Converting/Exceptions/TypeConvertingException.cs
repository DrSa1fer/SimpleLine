using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Services.Invokation.Converting.Exceptions
{
    internal class TypeConvertingException : SimpleLineException
    {
        internal TypeConvertingException(string input)
            : base($"Some wrong with converting an input {input}")
        {
        }
    }
}