namespace SimpleLineLibrary.Services.Execution.Converting.Exceptions
{
    internal class IsNotArrayException : Exception
    {
        public IsNotArrayException()
            : base("Supported only array collections converting")
        {
        }
    }
}
