using SimpleLineLibrary.Services.Finding.Parsing;
using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Setup;
using System.Reflection;

namespace SimpleLineLibrary.Services.Finding
{
    internal class CommandFinder
    {
        private readonly CommandDefinitionsParser _definitionsReader;

        public CommandFinder()
        {
            _definitionsReader = new();
        }

        public Command? Find(Queue<string> args, IEnumerable<TypeInfo> types)
        {
            if (args.Count < 1)
            {
                return null;
            }

            var dict = _definitionsReader.GetDefinitions(types);

            if (dict.TryGetValue(args.Peek(), out CommandDefinition? command))
            {
                args.Dequeue();
            }
            else
            {
                return null;
            }

            while (args.Count > 0)
            {
                if (command.Subcommands.ContainsKey(args.Peek()))
                {
                    command = command.Subcommands[args.Peek()];
                    args.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (command.Method == null || command.Type == null)
            {
                throw new InvalidOperationException("Command not register");
            }

            var obj = command.Method.IsStatic ? null : Activator.CreateInstance(command.Type);

            return MakeCommand(command.Uid, command.Method, obj);
        }

        private static Command MakeCommand(string uid, MethodInfo? info, object? obj)
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
    }       
}