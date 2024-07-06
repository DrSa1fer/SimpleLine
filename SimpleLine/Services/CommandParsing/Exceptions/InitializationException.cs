namespace SimpleLineLibrary.Services.CommandParsing.Exceptions
{
    internal class InitializationException : Exception
    {
        public InitializationException(Exception innerException) : base("Initialization exception:\n" + innerException.Message, innerException)
        {
        }
    }
}