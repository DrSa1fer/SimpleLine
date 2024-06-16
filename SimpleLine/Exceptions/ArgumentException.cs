using System.Runtime.Serialization;

namespace SimpleLineLibrary.Exceptions
{
    internal class ArgumentException : SimpleLineException
    {
        public ArgumentException()
        {
        }

        public ArgumentException(string? message) : base(message)
        {
        }

        public ArgumentException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public ArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
