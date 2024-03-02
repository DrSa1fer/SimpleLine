using SimpleLineLibrary.Src.Entities.Commands;
using SimpleLineLibrary.Src.Exceptions;
using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src
{
    public class SimpleLine
    {
        private readonly List<Command> _commands = new();
        
        public Command RegisterCommand(Command command) 
        {
            if(_commands.FirstOrDefault(x => x.Name == command.Name) != null)
            {
                throw new CommandRegistrationException(command.Name);
            }
            _commands.Add(command);
            return command;
        }
        public Command RegisterCommand(string name, string helpInfo)
        {
            return RegisterCommand(new Command(name, helpInfo));
        }

        public void Run(string[] args)
        {
            var input = InputData.Make(args);
            _commands.Find(x => x.Name == input.CommandName)?.Execute(input);
        }
        public void Run()
        {
            Run(Environment.GetCommandLineArgs());
        }
    }
}
