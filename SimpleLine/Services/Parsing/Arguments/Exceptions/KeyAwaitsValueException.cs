namespace SimpleLineLibrary.Services.Parsing.Arguments.Exceptions
{
    internal class KeyAwaitsValueException : Exception
    {
        public KeyAwaitsValueException(string key)
            : base($"key {key} awaits value before '='")
        {

        }
    }
}
