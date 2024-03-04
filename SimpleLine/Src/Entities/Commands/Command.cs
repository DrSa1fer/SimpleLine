using SimpleLineLibrary.Src.Entities.Parameters.Info;
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
        private List<ParameterInfo> _info { get; } = new();

        internal void Execute(InputData inputData)
        {
            Handler?.Invoke(inputData);
        }
        internal void AddParameterInfo(ParameterInfo info)
        {
            _info.Add(info);
        }

        public override string ToString()
        {
            var res = "";

            res += new string('-', 64) + "\n";
            res += $"Name: {Name}\n";
            res += $"Desc: {Description}\n";
            res += "Parameters: \n";

            foreach(var parameter in _info)
            {
                res += "\t" + parameter.Info + "\n";
            }

            res += new string('-', 64);

            return res;
        }
    }
}