namespace SimpleLineLibrary.Extentions.Exceptions
{
    internal class InvalidTokenException : Exception
    {
        public InvalidTokenException(string token, string msg = "") 
            : base($"Invalid token {token}. Message: {msg}")
        {

        }
    }
}