using System.Runtime.Serialization;

namespace SimpleLineLibrary.Exceptions
{
    internal abstract class SimpleLineException : Exception
    {
        protected SimpleLineException()
        {
        }

        protected SimpleLineException(string? message) : base(message)
        {
        }

        protected SimpleLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected SimpleLineException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}