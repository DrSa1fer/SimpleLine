using SimpleLineLibrary.Utils.MessageBuilders;

namespace SimpleLineLibrary.Services.ReceivingInfo.Info
{
    internal abstract class BaseInfo
    {
        internal string Program { get; }
        internal string Version { get; }

        public BaseInfo(string program, string vers)
        {
            Program = program;
            Version = vers;
        }
    }
}