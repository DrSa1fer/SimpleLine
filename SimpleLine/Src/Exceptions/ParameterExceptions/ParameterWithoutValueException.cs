namespace SimpleLineLibrary.Src.Exceptions.ParameterExceptions
{
    public class ParameterWithoutValueException : Exception
    {
        public ParameterWithoutValueException() :
            base("Parameter must to have any value")
        {
        }

        public ParameterWithoutValueException(string parameter) 
            : base($"Parameter {parameter} must to have any value")
        {
        }
    }
}
