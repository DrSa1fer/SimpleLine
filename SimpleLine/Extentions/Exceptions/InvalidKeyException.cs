namespace SimpleLineLibrary.Extentions.Exceptions
{
    internal class InvalidKeyException : Exception
    {
        public InvalidKeyException(string key, string msg = "")
            : base($"Invalid key {key}. Message: {msg}")
        {

        }
    }
}