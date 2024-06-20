using SimpleLineLibrary.Extentions.Strings;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Assembly.Receiving
{
    internal class CommandProxy
    {        
        public string Uid { get; }
        public Command? Command { get; set; }
        public List<CommandProxy> Subcommands { get;  }

        public CommandProxy(string uid)
        {
            Subcommands = new();
            Uid = uid;
        }
    }
}
