using System.Reflection;
using System.IO;

namespace SimpleLineLibrary
{
    public class Configuration
    {
        /// <summary>
        /// Action when an error occurs inside the library
        /// </summary>
        /// <value></value>
        public Action<Exception>? OnSimpleLineException { get; set; }
        /// <summary>
        /// Action when an error occurs inside the user code
        /// </summary>
        /// <value></value>
        public Action<Exception>? OnUserException { get; set; }        
        /// <summary>
        /// Action when the command is not found
        /// </summary>
        /// <value></value>
        public Action<string>? OnCommandNotFound { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public Action<string>? OnHandlerMissing { get; set; }
        /// <summary>
        /// Action when no arguments were passed
        /// </summary>
        /// <value></value>
        public Action? OnNoArguments { get; set; }
        /// <summary>
        /// Action before run the library
        /// </summary>
        /// <value></value>
        public Action? OnBeforeRun { get; set; }
        /// <summary>
        /// Action after run the library
        /// </summary>
        /// <value></value>
        public Action? OnAfterRun { get; set; }

        /// <summary>
        /// Program name
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// Progrram description
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// Program version
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// Convertible Types
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Type, Func<string, object?>> ConvertibleTypes
        {
            get
            {
                return _convertibleTypes;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        public IReadOnlyDictionary<Type, Func<object?>> InjectibleTypes
        {
            get
            {
                return _injectibleTypes;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
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
        /// <summary>
        /// Keys which are considered keys to call help
        /// </summary>
        /// <value></value>
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

        private readonly Dictionary<Type, Func<string, object?>> _convertibleTypes;
        private readonly Dictionary<Type, Func<object?>> _injectibleTypes;

        private readonly IEnumerable<TypeInfo> _definedTypes;
        private IReadOnlySet<string> _helpKeys;

        /// <summary>
        /// Make empty configuration  
        /// </summary>
        public Configuration()
        {
            _programName = string.Empty;
            _programDesc = string.Empty;
            _programVers = string.Empty;

            _convertibleTypes = new Dictionary<Type, Func<string, object?>>();
            _injectibleTypes = new Dictionary<Type, Func<object?>>();
            _definedTypes = Enumerable.Empty<TypeInfo>();
            _helpKeys = new HashSet<string>();

            RegisterDefaultConverters();
            RegisterDefaultInjects();
        }

        /// <summary>
        /// Add type for inject
        /// </summary>
        /// <param name="func">Getting instance method</param>
        /// <typeparam name="T">Type for inject</typeparam>
        public void AddTypeForInject<T>(Func<T> func)
        {
            var wrapper = new Func<object?>(() => func());

            _injectibleTypes[typeof(T)] = wrapper;
        }

        /// <summary>
        /// Add type for converting 
        /// </summary>
        /// <param name="func">Convertation method</param>
        /// <typeparam name="T">Type for converting</typeparam>
        public void AddTypeForConverting<T>(Func<string, T> func)
        {
            var wrapper = new Func<string, object?>(input => func(input));

            _convertibleTypes[typeof(T)] = wrapper;
        }

        /// <summary>
        /// Make configuration with default values
        /// </summary>
        /// <param name="assembly">Target assembly</param>
        /// <returns>Configuration</returns>
        public static Configuration Default(Assembly assembly)
        {
            return new()
            {
                OnBeforeRun = () => {},
                OnAfterRun = () => {},
                OnUserException = (ex) =>
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    Console.WriteLine(ex.InnerException?.StackTrace);
                },
                OnSimpleLineException = (ex) =>
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                },
                OnCommandNotFound = (name) =>
                {
                    Console.WriteLine($"Simple Line doesnt contains command with name \"{name}\"");
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
                .GetCustomAttribute<AssemblyVersionAttribute>()?.Version ?? "1.0.0.0",

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
                if (new HashSet<string>(){"1", "y", "true"}.Contains(x.ToLower()))
                {
                    return true;
                }

                if (new HashSet<string>(){"0", "n", "false"}.Contains(x.ToLower()))
                {
                    return false;
                }

                throw new FormatException($"{x} is not bool");
            });

            AddTypeForConverting(char.Parse);
            AddTypeForConverting(x => x);
            AddTypeForConverting(x => new FileInfo(x));
            AddTypeForConverting(x => new DirectoryInfo(x));
        }

        private void RegisterDefaultInjects()
        {
            AddTypeForInject(() => new byte());
            AddTypeForInject(() => new short());
            AddTypeForInject(() => new int());
            AddTypeForInject(() => new long());
            AddTypeForInject(() => new float());
            AddTypeForInject(() => new double());
            AddTypeForInject(() => new decimal());
            AddTypeForInject(() => string.Empty);
            AddTypeForInject(() => new bool());
        }
    }
}