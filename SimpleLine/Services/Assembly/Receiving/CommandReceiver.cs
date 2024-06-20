using SimpleLineLibrary.Extentions.Strings;
using SimpleLineLibrary.Models;
using System.Reflection;
using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Services.Assembly.Receiving
{
    internal class CommandReceiver
    {
        internal List<Command> GetCommands(IEnumerable<TypeInfo> types)
        {
            var proxy = new Dictionary<string, CommandProxy>();
            var ls = new List<Command>();

            foreach (var t in types.Where(x => x.IsClass && !x.IsAbstract))
            {
                var defAttr = t.GetCustomAttribute<CommandDefinitionsAttribute>();

                if (defAttr == null)
                {
                    continue;
                }

                var defBindTo = defAttr.BindTo?
                    .SplitAndRemoveEmptyEntries(' ');

                foreach(var method in t.GetMethods())
                {
                    var comAttr = method.GetCustomAttribute<CommandAttribute>();

                    if (comAttr == null)
                    {
                        continue;
                    }

                    if(method.IsAbstract)
                    {
                        Console.WriteLine("Ignore abstarct method");
                    }

                    var comPath = new List<string>();

                    if (defBindTo is not null && defBindTo.Length > 0)
                    {
                        for(int i = 0; i < defBindTo.Length; i++)
                        {
                            var local_name = defBindTo[i];

                            local_name.ThrowIfWrongTokenName();
                            comPath.Add(local_name);
                        }
                    }

                    var comBindTo = comAttr.Command
                            .SplitAndRemoveEmptyEntries(' ');

                    if(comBindTo is null || comBindTo.Length < 1)
                    {
                        throw new ArgumentException("Command cant be null or empty");
                    }

                    for (int i = 0; i < comBindTo.Length; i++)
                    {
                        var local_name = comBindTo[i];

                        local_name.ThrowIfWrongTokenName();
                        comPath.Add(local_name);
                    }
                    
                    if (method.IsAbstract)
                    {
                        throw new NotSupportedException("Generic methods not supported");
                    }

                    if (method.IsGenericMethod)
                    {
                        throw new NotSupportedException("Generic methods not supported");
                    }

                    if(comPath.Count == 1)
                    {
                        var uid = comPath[^1];
                        var obj = method.IsStatic ? null : Activator.CreateInstance(t);
                        var com = MakeCommand(method, uid, obj);

                        ls.Add(com);
                    }
                    else
                    {
                        throw new NotImplementedException("Bigger than 1 depth commands not supported");
                    }
                }

            }

            return ls;
        }

        private Command MakeCommand(MethodInfo info, string uid, object? obj)
        {
            var name = info.Name;
            var desc = info.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";

            var func = new HandlerAction((x) => info.Invoke(obj, x));
            var pars = MakeParameters(info.GetParameters());
            var handler = new Handler(func, pars);

            return new Command(uid, name, desc, handler);
        }

        private Parameter[] MakeParameters(ParameterInfo[] info)
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
