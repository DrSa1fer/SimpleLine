namespace SimpleLineLibrary.Services.Execution.Exceptions.Binding
{
    internal class NotSupportedTypeException : BindingException
    {
        public NotSupportedTypeException(Type type) 
            : base("")
        {
        }
    }
}
