namespace SimpleLineLibrary.Services.TypeFinding.Activation.Exceptions
{
    public class CtorNotFoundException : Exception
    {
        public CtorNotFoundException(Type type) 
            : base($"Type {type} doesnt contains constructor with avalible inject types")
        {
        }
    }
}