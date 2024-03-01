namespace SimpleLineLibrary.Src.Exceptions
{
    public class CommandRegistrationException : Exception
    {
        public CommandRegistrationException(string commandName)
            : base($"Command with name \"{commandName}\" was registered already"){ }
    }
}
