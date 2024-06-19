using SimpleLineLibrary.Models;
using SimpleLineLibrary.Setup.Attributes;
using System.Reflection;

namespace SimpleLineLibrary.Setup
{
    internal sealed class CommandProvider
    {
        private readonly IEnumerable<TypeInfo> _types;
        public CommandProvider(IEnumerable<TypeInfo> types)
        {
            _types = types;
        }

        internal List<Command> GetCommands()
        {
            var ls = new List<Command>();

            foreach (var t in _types.Where(x => x.IsClass && !x.IsAbstract))
            {
                var commandAttr = t.GetCustomAttribute<CommandAttribute>();

                if (commandAttr == null)
                {
                    continue;
                }

                var sp = commandAttr.Command.Split
                (
                    new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries
                );

                if (sp.Length < 1)
                {
                    throw new ArgumentException("Empty name");
                }

                Command? com = null;


                if (sp.Length == 1)
                {
                    var uid = sp[0];

                    if (uid.StartsWith('@'))
                    {
                        //   com = MakeCommand(t, uid, false);
                        throw new NotImplementedException("@names not implemented");
                    }
                    else
                    {
                        com = MakeCommand(t, uid, true);
                    }
                }
                else if (sp.Length > 1)
                {
                    throw new NotImplementedException();
                }

                if (com == null)
                {
                    continue;
                }

                ls.Add(com);

                var ctor = t.GetConstructor(Type.EmptyTypes);

                if (ctor == null)
                {
                    continue;
                }

                var obj = ctor.Invoke(null);

                foreach (var method in t.GetMethods())
                {
                    var handlerAttr = method.GetCustomAttribute<HandlerAttribute>();

                    if (handlerAttr == null)
                    {
                        continue;
                    }

                    var key = handlerAttr.Key;
                    var han = MakeHandler(method, obj, key);

                    if (com.ContainsHandler(han))
                    {
                        Console.WriteLine("Handler will be ignored: " + han.Name);
                    }
                    else
                    {
                        com.RegisterHandler(han);
                    }
                }
            }

            return ls;
        }

        private static Command MakeCommand(TypeInfo info, string uid, bool check = true)
        {
            var name = info.Name;
            var desc = info.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";

            return new Command(uid, name, desc, check);
        }

        private static Handler MakeHandler(MethodInfo info, object? obj, string key)
        {
            var name = info.Name;
            var desc = info.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";
            var func = new HandlerAction((x) => info.Invoke(obj, x));

            var pars = MakeParameters(info.GetParameters());

            return new Handler(name, desc, key, func, pars);
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

                if(keysAttr == null)
                {
                    @long = name;

                    throw new NotImplementedException("Short key finding. line 153");
                }
                else
                {
                    @long = keysAttr.LongKey; 
                    @short = keysAttr.ShortKey;
                }

                arr[i] = new Parameter(name, desc, @long, @short, pos, req, val, def);
            }

            return arr;
        }
    }
}