using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Setup;
using System.Reflection;

namespace SimpleLineLibrary.Services.Finding
{
    internal class CommandFinder
    {
        internal Command? Find(Queue<string> args, IEnumerable<TypeInfo> types)
        {
            if (args.Count < 1)
            {
                return null;
            }

            var dict = GetCommandsProxy(types);

            if (dict.TryGetValue(args.Peek(), out CommandProxy? commandProxy))
            {
                args.Dequeue();
            }
            else
            {
                return null;
            }

            while (args.Count > 0)
            {
                if (commandProxy.Subcommands.ContainsKey(args.Peek()))
                {
                    commandProxy = commandProxy.Subcommands[args.Peek()];
                    args.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (commandProxy.Command == null)
            {
                throw new InvalidOperationException("Command not register");
            }

            return commandProxy.Command;
        }

        private static Dictionary<string, CommandProxy> GetCommandsProxy(IEnumerable<TypeInfo> types)
        {
            var root = new CommandProxy("");

            foreach (var t in types.Where(x => x.IsClass && !x.IsAbstract))
            {
                var defAttr = t.GetCustomAttribute<CommandDefinitionsAttribute>();

                if (defAttr == null)
                {
                    continue;
                }

                var defRoot = root;
                var defTokens = defAttr.Command.SplitAndRemoveEmptyEntries(' ');
                
                if (defTokens.Length > 0)
                {
                    foreach (var defToken in defTokens)
                    {
                        defToken.ThrowIfWrongTokenName();
                    }

                    defRoot = MakeProxy(defRoot, defTokens);
                }

                object? obj = null;

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

                    var comTokens = comAttr.Command.SplitAndRemoveEmptyEntries(' ');

                    if (comTokens.Length < 1)
                    {
                        throw new ArgumentException("Empty command name");
                    }

                    foreach (var comToken in comTokens)
                    {
                        comToken.ThrowIfWrongTokenName();
                    }

                    comRoot = MakeProxy(comRoot, comTokens);

                    obj ??= m.IsStatic ? null : Activator.CreateInstance(t);

                    var uid = comRoot.Uid;

                    if(comRoot.Command != null)
                    {
                        throw new Exception($"Already register command to uid \"{uid}\"");
                    }

                    comRoot.Command = MakeCommand(m, uid, obj);
                }
            }

            return root.Subcommands;
        }

        private static CommandProxy MakeProxy(CommandProxy root, string[] tokens)
        {
            var locRoot = root;

            for (int i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];

                if (locRoot.Subcommands.ContainsKey(token))
                {
                    locRoot = locRoot.Subcommands[token];
                }
                else
                {
                    var temp = new CommandProxy(token);

                    locRoot.Subcommands[token] = temp;
                    locRoot = temp;
                }
            }

            return locRoot;
        }

        private static Command MakeCommand(MethodInfo? info, string uid, object? obj)
        {
            Handler? handler = null;
            var desc = info?.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";

            if (info != null)
            {
                handler = MakeHandler(info, obj);
            }

            return new Command(uid, desc, handler);
        }
        private static Handler MakeHandler(MethodInfo info, object? obj)
        {
            var func = new HandlerAction((x) => info.Invoke(obj, x));
            var pars = MakeParameters(info.GetParameters());

            return new Handler(func, pars);
        }
        private static Parameter[] MakeParameters(ParameterInfo[] info)
        {
            var names = info.Select(x => x.Name ?? x.Position.ToString()).ToArray();

            var arr = new Parameter[info.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var p = info[i];

                var pos = p.Position;
                var req = !p.IsOptional;
                var val = p.ParameterType;
                var def = p.DefaultValue;

                var name = p.Name ?? pos.ToString();
                var desc = p.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";

                var @long = string.Empty;
                var @short = string.Empty;

                var keysAttr = p.GetCustomAttribute<CustomKeysAttribute>();

                if (keysAttr == null)
                {
                    @long = $"--{name}";
                    
                    for(int j = 0; j < name.Length; j++)
                    {
                        int count = 0;
                        foreach(var n in names)
                        {
                            var sym = n.Skip(j).Take(1).SingleOrDefault();
                            
                            if(sym == name[j])
                            {
                                count++;
                            }
                        }
                        if(count < 2)
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

        private class CommandProxy
        {
            public string Uid { get; }
            public Command? Command { get; set; }
            public Dictionary<string, CommandProxy> Subcommands { get; }

            public CommandProxy(string uid)
            {
                Subcommands = new();
                Uid = uid;
            }
        }
    }
}