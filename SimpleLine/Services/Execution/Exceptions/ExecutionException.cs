using SimpleLineLibrary.Services.Exceptions;

namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class ExecutionException : ServiceException
    {
        public ExecutionException(Exception ex) 
            : base("", ex)
        { 
        }
    }
}
