using System.Runtime.Serialization;

namespace SimpleLineLibrary.Exceptions
{
    [Serializable]
    internal class SimpleLineException : Exception
    {
        public SimpleLineException()
        {
        }

        public SimpleLineException(string? message) : base(message)
        {
        }

        public SimpleLineException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SimpleLineException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
