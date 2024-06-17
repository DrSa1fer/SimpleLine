using System.Runtime.Serialization;
using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Setup.Exceptions
{
    internal class SetupException : SimpleLineException
    {
        public SetupException()
        {
        }

        public SetupException(string? message) : base(message)
        {
        }

        public SetupException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SetupException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
