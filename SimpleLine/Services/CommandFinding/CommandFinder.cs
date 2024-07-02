using SimpleLineLibrary.Services.CommandFinding.Activation;
using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Setup;
using System.Reflection;
using SimpleLineLibrary.Services.CommandFinding.Parsing;

namespace SimpleLineLibrary.Services.CommandFinding
{
    internal class CommandFinder
    {
        private readonly DIActivator _activator;
        private readonly NodeParser _nodeParser;

        public CommandFinder(IReadOnlyDictionary<Type, Func<object?>> injectibleTypes, string contextOperator = ".")
        {
            _activator = new DIActivator(injectibleTypes);
            _nodeParser = new NodeParser(contextOperator);
        }

        public Command? Find(Queue<string> args, IEnumerable<TypeInfo> types)
        {
            var root = _nodeParser.GetNode(types);

            while (args.TryPeek(out string? peek))
            {
                if (!root.Subcommands.ContainsKey(peek))
                {
                    break;
                }

                root = root.Subcommands[args.Dequeue()];
            }

            if (root.Type == null)
            {
                throw new InvalidOperationException("Command not register");
            }

            var obj = root.Method?.IsStatic is false ? _activator.CreateInstance(root.Type) : null;

            return MakeCommand(root.Uid, root.Method, obj);
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
                var desc = p.GetCustomAttribute<DescriptionAttribute>()?.Description ?? string.Empty;

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