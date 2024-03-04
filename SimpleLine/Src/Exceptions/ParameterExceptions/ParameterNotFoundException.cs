namespace SimpleLineLibrary.Src.Exceptions.ParameterExceptions
{
    public class ParameterNotFoundException : Exception
    {
        public ParameterNotFoundException()
            : base("Parameter was not found")
        {
        }

        public ParameterNotFoundException(string parameter) 
            : base($"Parameter {parameter} was not found")
        {
        }
    }
}
