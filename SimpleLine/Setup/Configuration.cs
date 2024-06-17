namespace SimpleLineLibrary.Setup
{
    public class Configuration
    {
        public Action<Exception> ExceptionHandler { get; init; } =
        (ex) =>
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        };

        public Action? NoneArgsHandler { get; init; } =
        () =>
        {
            var output = "";
            var newline = Environment.NewLine;

            output += " _____   _   ___   ___   _____   _       _____      _       _   ___   _   _____  " + newline;
            output += "|  ___| |_| |   |_|   | |  _  | | |     |  ___|    | |     |_| |   |_| | |  ___| " + newline;
            output += "| |___   _  | |_   _| | | |_| | | |     | |___     | |      _  | |_  | | | |___  " + newline;
            output += "|___  | | | | | |_| | | |  ___| | |     |  ___|    | |     | | | | |_  | |  ___| " + newline;
            output += " ___| | | | | |     | | | |     | |___  | |___     | |___  | | | |   | | | |___  " + newline;
            output += "|_____| |_| |_|     |_| |_|     |_____| |_____|    |_____| |_| |_|   |_| |_____| " + newline;

            Console.WriteLine(output);
        };

        public Action<string> CommandNotFound { get; init; } =
            (name) => Console.WriteLine($"Simple Line doesnt contains command with name \"{name}\" name");            

        public Action<IList<string>> HandlerNotFound { get; init; } =
            (args) => Console.WriteLine($"Simple Line doesnt contains handler with args {string.Join("; ", args)}");

        public HashSet<string> HelpKeys { get; init; } =
            new() { "-h", "-?", "--help", "--info" };
    }
}