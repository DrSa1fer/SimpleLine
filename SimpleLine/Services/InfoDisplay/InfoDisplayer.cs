using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Models.Info;

namespace SimpleLineLibrary.Services.InfoDisplay
{
    internal class InfoDisplayer
    {
        private readonly IReadOnlySet<string> _helpKeys;
        private readonly string _program;
        private readonly string _vers;

        public InfoDisplayer(IReadOnlySet<string> helpKeys, string program, string vers) 
        {
            _helpKeys = helpKeys;
            _program = program;
            _vers = vers;
        }

        public string GetInfo(Command command)
        {
            return new CommandInfo(command, _program, _vers).ToString();
        }

        public string GetInfo(Handler handler)
        {
            return new HandlerInfo(handler, _program, _vers).ToString();
        }
    }
}
