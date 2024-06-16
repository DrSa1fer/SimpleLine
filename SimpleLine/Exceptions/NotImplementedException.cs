using System.Runtime.Serialization;

namespace SimpleLineLibrary.Exceptions
{
    internal class NotImplementedException : SimpleLineException
    {
        public NotImplementedException()
        {            
        }

        public NotImplementedException(string? message) : base(message)
        {
        }

        public NotImplementedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public NotImplementedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
