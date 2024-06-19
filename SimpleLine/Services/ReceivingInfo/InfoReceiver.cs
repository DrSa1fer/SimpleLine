using SimpleLineLibrary.Models;
using SimpleLineLibrary.Models.Info;

namespace SimpleLineLibrary.Services.InfoRecieving
{
    internal class InfoReceiver
    {
        private readonly string _program;
        private readonly string _vers;

        public InfoReceiver(string program, string vers) 
        {
            _program = program;
            _vers = vers;
        }

        public string ReceiveFrom(Command command)
        {
            return new CommandInfo(command, _program, _vers).ToString();
        }

        public string ReceiveFrom(Handler handler)
        {
            return new HandlerInfo(handler, _program, _vers).ToString();
        }
    }
}
