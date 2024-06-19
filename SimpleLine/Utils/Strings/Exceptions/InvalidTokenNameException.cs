namespace SimpleLineLibrary.Utils.Strings.Exceptions
{
    internal class InvalidTokenNameException : Exception
    {
        internal InvalidTokenNameException(string msg)
            : base($"Invalid token name {msg?.ToString()}")
        { }
    }
}
