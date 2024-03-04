namespace SimpleLineLibrary.Src.Exceptions.ParameterExceptions
{
    public class KeyWithValueException : Exception
    {
        public KeyWithValueException() : base("Key cant contains any value")
        {
        }
        public KeyWithValueException(string key) 
            : base($"Key {key} cant contains any value")
        {

        }
    }
}
