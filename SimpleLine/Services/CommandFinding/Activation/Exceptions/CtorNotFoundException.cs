namespace SimpleLineLibrary.Services.CommandFinding.Activation.Exceptions
{
    internal class CtorNotFoundException : Exception
    {
        public CtorNotFoundException(Type type)
            : base($"Type {type} doesnt contains constructor with avalible inject types")
        {
        }
    }
}