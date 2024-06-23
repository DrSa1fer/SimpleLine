namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class UserRuntimeException : Exception
    {
        internal UserRuntimeException(Exception? innerException)
            : base("Problems in user code", innerException)
        {
        }
    }
}
