using SimpleLineLibrary.Services.Exceptions;

namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class UserRuntimeException : ServiceException
    {
        internal UserRuntimeException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
    }
}
