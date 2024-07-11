namespace SimpleLineLibrary.Services.Execution.Binding.Exceptions
{
    internal class RequiredParameterIsMissingException : Exception
    {
        public RequiredParameterIsMissingException(string name)
            : base($"Required parameter is missing {name}")
        { }
    }
}
