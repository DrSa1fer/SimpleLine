using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Services.Invokation.Execution.Exceptions
{
    internal class UserRuntimeException : SimpleLineException
    {
        public Exception UserException
        {
            get
            {
                return _exception;
            }
        }

        private readonly Exception _exception;

        internal UserRuntimeException(Exception exception) : base(exception.Message)
        {
            _exception = exception;
        }
    }
}
