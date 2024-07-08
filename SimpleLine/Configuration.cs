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
        /// 
        /// </summary>
        /// <value></value>
        public Action<Exception>? OnInitializationException { get; set; }
        /// <summary>
        /// Action when an error occurs inside the user code
        /// </summary>
        /// <value></value>
        public Action<Exception>? OnUserException { get; set; }
        /// <summary>
        /// Action on exception in command execution 
        /// </summary>
        public Action<Exception>? OnExecutionException { get; set; }
        /// <summary>
        /// Action on command not found
        /// </summary>
        public Action<string>? OnCommandMissing { get; set; }
        /// <summary>
        /// Action on implimentation of command is missing
        /// </summary>
        public Action<string>? OnCommandActionMissing { get; set; }
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
        /// Action on getting help
        /// </summary>
        public Action<string>? OnGetHelp { get; set; }

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
        /// Injectible types
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
                return _definedTypes ?? Enumerable.Empty<TypeInfo>();
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
                return _helpKeys ?? new HashSet<string>();
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

        private readonly IEnumerable<TypeInfo>? _definedTypes;
        private readonly IReadOnlySet<string>? _helpKeys;

        /// <summary>
        /// Make empty configuration  
        /// </summary>
        public Configuration()
        {
            _programName = string.Empty;
            _programDesc = string.Empty;
            _programVers = string.Empty;
            
            _helpKeys = new HashSet<string>() { "-?", "-h", "--help" };

            _convertibleTypes = new Dictionary<Type, Func<string, object?>>();
            _injectibleTypes = new Dictionary<Type, Func<object?>>();
            _definedTypes = Enumerable.Empty<TypeInfo>();

            RegisterDefaultConverters();
            RegisterDefaultInjects();
        }

        /// <summary>
        /// Add type for inject
        /// </summary>
        /// <param name="func">Getting instance method</param>
        /// <typeparam name="T">Type for inject</typeparam>
        public void AddTypeForInjecting<T>(Func<T> func)
        {
            var wrapper = new Func<object?>(() => func());

            _injectibleTypes[typeof(T)] = wrapper;
        }

        /// <summary>
        /// Add type for inject
        /// </summary>
        /// <param name="obj">Instance of object</param>
        /// <typeparam name="T">Type for inject</typeparam>
        public void AddTypeForInjecting<T>(T obj)
        {
            var wrapper = new Func<object?>(() => obj);

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
                OnInitializationException = (ex) =>
                {
                    Console.WriteLine(ex.Message);
                },
                OnUserException = (ex) =>
                {
                    Console.WriteLine(ex.Message);

                    Console.WriteLine(ex.InnerException?.Message);
                    Console.WriteLine(ex.InnerException?.StackTrace);
                },
                OnExecutionException = (ex) =>
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Use --help for more info about command");
                },
                OnSimpleLineException = (ex) =>
                {
                    Console.WriteLine(ex.Message);
                },
                OnCommandMissing = (name) =>
                {
                    Console.WriteLine($"Command with name \"{name}\" is missing");
                },
                OnCommandActionMissing = (name) => 
                {                    
                    Console.WriteLine($"Action of command with name \"{name}\" is missing");
                },
                OnGetHelp = (help) =>
                {
                    Console.WriteLine(help);
                },                
                DefinedTypes = assembly.DefinedTypes,
                ProgramName = assembly.ManifestModule.Name,
                ProgramVersion = assembly.GetCustomAttribute<AssemblyVersionAttribute>()?.Version ?? "1.0.0.0",
                ProgramDescription = assembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? string.Empty,
                HelpKeys = new HashSet<string>() { "-h", "-?", "--help", "--info" },
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

            AddTypeForConverting(char.Parse);
            AddTypeForConverting(x => x);
            AddTypeForConverting(x => new FileInfo(x));
            AddTypeForConverting(x => new DirectoryInfo(x));
           
            AddTypeForConverting(x =>
            {
                if (new HashSet<string>() { "1", "y", "yes", "true" }.Contains(x.ToLower()))
                    return true;

                if (new HashSet<string>() { "0", "n", "no", "false" }.Contains(x.ToLower()))
                    return false;

                throw new FormatException($"Cant convert {typeof(string).Name} to {typeof(bool).FullName}");
            }); 
        }

        private void RegisterDefaultInjects()
        {
            AddTypeForInjecting(new byte());
            AddTypeForInjecting(new short());
            AddTypeForInjecting(new int());
            AddTypeForInjecting(new long());
            AddTypeForInjecting(new float());
            AddTypeForInjecting(new double());
            AddTypeForInjecting(new decimal());
            AddTypeForInjecting(string.Empty);
            AddTypeForInjecting(new bool());
        }
    }
}