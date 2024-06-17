using SimpleLineLibrary.Utils.MessageBuilders;

namespace SimpleLineLibrary.Models.Info
{
    public abstract class BaseInfo
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