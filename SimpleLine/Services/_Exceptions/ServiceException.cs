using SimpleLineLibrary.Exceptions;
using System.Runtime.Serialization;

namespace SimpleLineLibrary.Services.Exceptions
{
    internal abstract class ServiceException : SimpleLineException
    {
        protected ServiceException()
        {
        }

        protected ServiceException(string? message) : base(message)
        {
        }

        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected ServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
