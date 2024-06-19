using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Utils.Strings;
using System.Reflection;

namespace SimpleLineLibrary.Setup
{
    public class Configuration
    {        
        public Action<Exception> ExceptionHandler { get; set; } =
        (ex) =>
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        };

        public Action? NoneArgsHandler { get; set; } =
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

        public Action<string> CommandNotFound { get; set; } =
            (name) => Console.WriteLine($"Simple Line doesnt contains command with name \"{name}\" name");            

        public Action<IEnumerable<string>> HandlerNotFound { get; set; } =
            (args) => Console.WriteLine($"Simple Line doesnt contains handler with args {string.Join("; ", args)}");

        public HashSet<string> HelpKeys 
        {
            get
            {
                return _helpKeys;
            }
            set
            {
                if(value.Any(x => !x.IsKeyTokenName()))
                {
                    throw new Exception();
                }
                _helpKeys = value;
            }
        }

        internal string ProgramName
        {
            get
            {
                return _assembly.GetName().Name ?? "";
            }
        }

        internal string ProgramVersion
        {
            get
            {
                return _assembly.GetName().Version?.ToString() ?? "";
            }
        }

        internal Converter Converter
        {
            get
            {
                return _converter;
            }
        }

        internal CommandProvider CommandProvider
        {
            get
            {
                return _commandProvider;
            }
        }

        private readonly CommandProvider _commandProvider;
        private readonly Converter _converter;
        
        private readonly Assembly _assembly;
        private HashSet<string> _helpKeys;

        public Configuration(Assembly assembly)
        {
            _assembly = assembly;

            _helpKeys = new() { "-h", "-?", "--help", "--info" };

            _commandProvider = new CommandProvider(assembly.DefinedTypes);
            _converter = new Converter();

            RegisterDefaultConverters();
        }

        public void RegisterType<T>(Func<string, T> converter)
        {
           _converter.RegisterType(converter);
        }

        private void RegisterDefaultConverters()
        {
            _converter.RegisterType(int.Parse);
            _converter.RegisterType(x => x);
        }
    }
}