using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Commands
{
    public class Command 
    {
        public Command(string name, string desc = "")
        {
            Name = name;
            Description = desc;
        }

        public string Name { get; }
        public string Description { get; }

        internal Action<InputData>? Handler;

        internal void Execute(InputData inputData)
        {
            Handler?.Invoke(inputData);
        }
    }
}