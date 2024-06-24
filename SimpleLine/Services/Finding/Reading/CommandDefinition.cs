using System.Reflection;

namespace SimpleLineLibrary.Services.Finding.Reading
{
    internal class CommandDefinition
    {
        public string Uid 
        {
            get;
        }

        public Dictionary<string, CommandDefinition> Subcommands
        { 
            get;
        }

        public TypeInfo? Type 
        {   
            get;     
            set;
        }

        public MethodInfo? Method
        {
            get; 
            set;
        }

        public CommandDefinition(string uid)
        {
            Uid = uid;
            Subcommands = new();
        }
    }
}