namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class ExecutionException : Exception
    {
        public ExecutionException(Exception innerException) : base("Execution exception:\n" + innerException.Message, innerException)
        {
        }
    }
}