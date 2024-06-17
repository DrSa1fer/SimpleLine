using SimpleLineLibrary.Services.Exceptions;
using System.Runtime.Serialization;

namespace SimpleLineLibrary.Services.Execution.Exceptions.Binding
{
    internal class BindingException : ServiceException
    {
        public BindingException()
        {
        }

        public BindingException(string? message) : base(message)
        {
        }

        public BindingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BindingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
