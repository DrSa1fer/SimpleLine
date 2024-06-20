using System.Reflection;
using System.IO;
using System.Xml.Linq;

namespace SimpleLineLibrary
{
    public class Configuration
    {
        public Action<Exception>? OnSimpleLineException { get; init; }
        public Action<Exception>? OnUserException { get; init; }
        public Action<string>? OnCommandNotFound { get; init; }
        public Action<string>? OnHandlerMissing { get; init; }
        public Action? OnNoArguments { get; init; }

        public string ProgramName
        {
            get
            {
                return _programName;
            }
            init
            {
                _programName = value;
            }
        }
        public string ProgramDescription
        {
            get
            {
                return _programDesc;
            }
            init
            {
                _programDesc = value;
            }
        }
        public string ProgramVersion
        {
            get
            {
                return _programVers;
            }
            init
            {
                _programVers = value;
            }
        }
        public IReadOnlyDictionary<Type, Func<string, object?>> ConvertibleTypes
        {
            get
            {
                return _types;
            }
        }
        public IEnumerable<TypeInfo> DefinedTypes
        {
            get
            {
                return _definedTypes ?? Array.Empty<TypeInfo>();
            }
            init
            {
                _definedTypes = value;
            }
        }
        public IReadOnlySet<string> HelpKeys
        {
            get
            {
                return _helpKeys;
            }
            init
            {
                _helpKeys = value;
            }
        }

        private readonly string _programName;
        private readonly string _programVers;
        private readonly string _programDesc;

        private readonly Dictionary<Type, Func<string, object?>> _types;
        private readonly IEnumerable<TypeInfo> _definedTypes;
        private IReadOnlySet<string> _helpKeys;

        public Configuration()
        {
            _programName = string.Empty;
            _programDesc = string.Empty;
            _programVers = string.Empty;

            _types = new Dictionary<Type, Func<string, object?>>();
            _definedTypes = Enumerable.Empty<TypeInfo>();
            _helpKeys = new HashSet<string>();

            RegisterDefaultConverters();
        }

        public void AddTypeForConverting<T>(Func<string, T> func)
        {
            var wrapper = new Func<string, object?>(input => func(input));

            _types[typeof(T)] = wrapper;
        }

        public static Configuration Default(Assembly assembly)
        {
            return new()
            {
                OnUserException = (ex) =>
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                },
                OnSimpleLineException = (ex) =>
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                },
                OnCommandNotFound = (name) =>
                {
                    Console.WriteLine($"Simple Line doesnt contains command with name \"{name}\" name");
                },
                OnHandlerMissing = (name) => 
                {
                    Console.WriteLine($"Handler for command {name} is missing");
                },
                DefinedTypes = assembly.DefinedTypes,
                HelpKeys = new HashSet<string>() { "-h", "-?", "--help", "--info" },
                OnNoArguments = () =>
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
                },

                ProgramName = assembly.ManifestModule.Name,

                ProgramVersion = assembly
                .GetCustomAttribute<AssemblyVersionAttribute>()?.Version ?? string.Empty,

                ProgramDescription = assembly
                .GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty,
            };
        }

        private void RegisterDefaultConverters()
        {
            AddTypeForConverting(byte.Parse);
            AddTypeForConverting(sbyte.Parse);
            AddTypeForConverting(short.Parse);
            AddTypeForConverting(ushort.Parse);
            AddTypeForConverting(int.Parse);
            AddTypeForConverting(uint.Parse);
            AddTypeForConverting(long.Parse);
            AddTypeForConverting(ulong.Parse);

            AddTypeForConverting(float.Parse);
            AddTypeForConverting(double.Parse);
            AddTypeForConverting(decimal.Parse);

            AddTypeForConverting(x =>
            {
                var trueSet = new HashSet<string>()
                {
                    "1", "y", "true"
                };

                var falseSet = new HashSet<string>()
                {
                    "0", "n", "false"
                };

                if (trueSet.Contains(x.ToLower()))
                {
                    return true;
                }

                if (falseSet.Contains(x.ToLower()))
                {
                    return false;
                }

                throw new ArgumentException($"{x} is not bool");
            });

            AddTypeForConverting(char.Parse);
            AddTypeForConverting(x => x);
            AddTypeForConverting(x => new FileInfo(x));
            AddTypeForConverting(x => new DirectoryInfo(x));
        }
    }
}