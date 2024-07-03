using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.CommandParsing.Activation;
using SimpleLineLibrary.Services.CommandParsing.Exceptions;
using SimpleLineLibrary.Setup;
using SimpleLineLibrary.Setup.Help;
using System.Reflection;

namespace SimpleLineLibrary.Services.CommandParsing
{
    internal class CommandParser
    {
        private readonly string _programName;
        private readonly DIActivator _activator;

        public CommandParser(string programName, IReadOnlyDictionary<Type, Func<object?>> injectibleTypes)
        {
            _programName = programName;
            _activator = new(injectibleTypes);
        }

        internal Command GetCommands(IEnumerable<TypeInfo> types)
        {
            try
            {
                var root = new Command(_programName);

                foreach (var t in types.Where(x => x.IsClass && !x.IsAbstract))
                {
                    var defAttr = t.GetCustomAttribute<CommandsDefinitionsAttribute>();

                    if (defAttr == null)
                    {
                        continue;
                    }

                    var defRoot = root;

                    if (defAttr.Command.Length > 0)
                    {
                        var defTokens = defAttr.Command.SplitOnTokens(' ');

                        foreach (var defToken in defTokens)
                        {
                            defToken.ThrowIfWrongTokenName();
                        }

                        defRoot = MakeCommand(defRoot, defTokens);
                    }

                    foreach(var help in t.GetCustomAttributes<HelpBlockAttribute>())
                    {
                        defRoot.HelpBlocks.Add(new HelpBlock(help.Header, help.Body, help.Priority));
                    }

                    

                    foreach (var m in t.GetMethods())
                    {
                        var comAttr = m.GetCustomAttribute<CommandAttribute>();

                        if (comAttr == null)
                        {
                            continue;
                        }

                        if (m.IsAbstract)
                        {
                            throw new NotSupportedException("Abstract method is not supported");
                        }

                        if (m.IsGenericMethod)
                        {
                            throw new NotSupportedException("Generic method is not supported");
                        }

                        var comRoot = defRoot;

                        if (comAttr.Command.Length > 0)
                        {
                            var comTokens = comAttr.Command.SplitOnTokens(' ');

                            foreach (var comToken in comTokens)
                            {                           
                                comToken.ThrowIfWrongTokenName();
                            }

                            comRoot = MakeCommand(comRoot, comTokens);
                        }

                        if (comRoot.Handler != null)
                        {
                            throw new Exception($"Already impliment command with uid \"{comRoot.Uid}\"");
                        }

                        foreach(var help in m.GetCustomAttributes<HelpBlockAttribute>())
                        {
                            comRoot.HelpBlocks.Add(new HelpBlock(help.Header, help.Body, help.Priority));
                        }

                        var obj = m.IsStatic ? null : _activator.CreateInstance(t);
                        var func = new HandlerAction(x => m.Invoke(obj, x));
                        var ps = MakeParameters(m.GetParameters());

                        comRoot.Handler = new Handler(func, ps);
                    }                    
                }
                
                return root;
            }
            catch(Exception e)
            {
                throw new InitializationException(e);
            }
        }

        private static Command MakeCommand(Command root, string[] tokens)
        {            
            for (int i = 0; i < tokens.Length; i++)
            {           
                if (!root.Children.ContainsKey(tokens[i]))
                {
                    root.Children[tokens[i]] = new Command(tokens[i]);
                }

                var temp = root;

                root = root.Children[tokens[i]];
                root.Parent = temp;
            }

            return root;
        }

        private static Parameter[] MakeParameters(ParameterInfo[] info)
        {
            var names = info.Select(x => x.Name ?? ((char)(x.Position % 26 + 67)).ToString());

            var arr = new Parameter[info.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var p = info[i];

                var pos = p.Position;
                var req = !p.IsOptional;
                var val = p.ParameterType;
                var def = p.DefaultValue;

                var name = p.Name ?? ((char)(pos % 26 + 67)).ToString();
                var desc = p.GetCustomAttribute<DescriptionAttribute>()?.Body ?? string.Empty;

                var @long = string.Empty;
                var @short = string.Empty;

                var keysAttr = p.GetCustomAttribute<CustomKeysAttribute>();

                if (keysAttr == null)
                {
                    @long = $"--{name}";

                    for (int j = 0; j < name.Length; j++)
                    {
                        int count = 0;
                        foreach (var n in names)
                        {
                            var sym = n.Skip(j).Take(1).SingleOrDefault();

                            if (sym == name[j])
                            {
                                count++;
                            }
                        }
                        if (count < 2)
                        {
                            @short = $"-{name[..(j + 1)]}";
                            break;
                        }
                    }
                }
                else
                {
                    @long = keysAttr.LongKey;
                    @short = keysAttr.ShortKey;
                }

                @long.ThrowIfWrongLongKeyTokenName();
                @short.ThrowIfWrongShortKeyTokenName();

                arr[i] = new Parameter(name, desc, @long, @short, pos, req, val, def);
            }

            return arr;
        }
    }
}