using System.IO;

namespace SimpleLineLibrary.Services.Logging
{
    internal class ConsoleLogger : ILogger
    {
        private readonly TextWriter _errors;
        private readonly TextWriter _warnings;
        private readonly TextWriter _messages;

        public ConsoleLogger(TextWriter errors, TextWriter warnings, TextWriter messages) 
        {
            _errors = errors;
            _warnings = warnings;
            _messages = messages;
        }

        public void WriteError(string? msg)
        {
            _errors.WriteLine(msg);
        }

        public void WriteMessage(string? msg)
        {
            _messages.WriteLine(msg);
        }

        public void WriteWarning(string? msg, int level = 0)
        {
            _warnings.WriteLine(msg);
        }
    }
}
