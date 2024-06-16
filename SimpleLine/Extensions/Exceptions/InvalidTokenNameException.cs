using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Extensions.Exceptions
{
    internal class InvalidTokenNameException : SimpleLineException
    {
        internal InvalidTokenNameException(string msg)
            : base($"Invalid token name {msg?.ToString()}")
        { }
    }
}
