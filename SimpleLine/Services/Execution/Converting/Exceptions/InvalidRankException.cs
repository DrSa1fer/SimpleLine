namespace SimpleLineLibrary.Services.Execution.Converting.Exceptions
{
    internal class InvalidRankException : Exception
    {
        public InvalidRankException()
            : base("Supported only array rank is 1 ")
        {
        }
    }
}
