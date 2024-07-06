namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class UserException : Exception
    {
        internal UserException(Exception innerException)
            : base("Problems in user code:\n" + innerException.Message, innerException)
        {
        }
    }
}
