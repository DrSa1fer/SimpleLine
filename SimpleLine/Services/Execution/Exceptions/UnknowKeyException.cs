namespace SimpleLineLibrary.Services.Execution.Exceptions
{
    internal class UnknowKeyException : Exception
    {
        public UnknowKeyException(string key, IEnumerable<string> avalible)
            : base($"Key is not contains in command. Avalible keys: {string.Join("|", avalible)}")
        {

        }  
    }
}