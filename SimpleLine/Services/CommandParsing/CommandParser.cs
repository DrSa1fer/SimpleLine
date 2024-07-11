using SimpleLineLibrary.Services.CommandParsing.Activation;
using SimpleLineLibrary.Services.CommandParsing.Exceptions;
using SimpleLineLibrary.Services.CommandParsing.HelpBlocks;
using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Setup;
using System.Reflection;

namespace SimpleLineLibrary.Services.CommandParsing
{
    internal class CommandParser
    {
        private readonly DIActivator _activator;

        public CommandParser(IReadOnlyDictionary<Type, Func<object?>> injectibleTypes)
        {
            _activator = new(injectibleTypes);
        }

        internal CommandNode GetCommands(IEnumerable<TypeInfo> types)
        {
            try
            {
                var root = new CommandNode("root");

                foreach (var t in types.Where(x => x.IsClass))
                {
                    var comAttr = t.GetCustomAttribute<CommandAttribute>();

                    if (comAttr == null)
                    {
                        continue;
                    }

                    var local = root;

                    if (comAttr.Command != null && comAttr.Command.Length > 0)
                    {
                        var tokens = comAttr.Command.SplitOnTokens(' ');

                        local = MakeNode(local, tokens);
                    }

                    if (local.Command != null)
                    {
                        throw new ArgumentException("Command already is registered: " + local.Uid);
                    }

                    local.Command = new Command(local.Uid);
                    
                    MethodInfo? m = t
                        .GetMethods()
                        .FirstOrDefault((x) => x.GetCustomAttribute<CommandActionAttribute>() != null);

                    if (m == null)
                    {
                        local.Command.HelpBlocksFunc = () =>
                        {
                            return new List<HelpBlock>
                            {
                                new SubcommandBlock(local),
                                new UsageBlock(local, "[OPTIONS] <ARGS>"),
                                new OptionBlock(local.Command)
                            };
                        };

                        continue;
                    }
                    
                    local.Command.ActionFunc = () =>
                    {
                        var obj = m.IsStatic ? null : _activator.CreateInstance(t);
                        var fn = new Func<object?[]?, object?>(x => m.Invoke(obj, x));
                        var ps = MakeParameters(m.GetParameters());

                        return new CommandAction(fn, ps);
                    };

                    local.Command.HelpBlocksFunc = () =>
                    {
                        return new List<HelpBlock>
                        {
                            new UsageBlock(local, "[OPTIONS] <ARGS>"),
                            new SubcommandBlock(local),
                            new OptionBlock(local.Command)
                        };                        
                    };
                }

                return root;
            }
            catch (Exception e)
            {
                throw new InitializationException(e);
            }
        }

        private static CommandNode MakeNode(CommandNode root, string[] tokens)
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                if (!root.Children.ContainsKey(tokens[i]))
                {
                    root.Children.Add(tokens[i], new CommandNode(tokens[i]));
                }

                var temp = root;

                root = root.Children[tokens[i]];
                root.Parent = temp;
            }

            return root;
        }

        private static Parameter[] MakeParameters(ParameterInfo[] info)
        {
            var names = info.Select(x => x.Name);

            var arr = new Parameter[info.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                var p = info[i];

                var pos = p.Position;
                var req = !p.IsOptional;
                var val = p.ParameterType;
                var def = p.DefaultValue;

                var name = p.Name?.ToString() ?? throw new Exception("Parameter name cant be null");

                var desc = string.Empty;
                var @long = string.Empty;
                var @short = string.Empty;

                var pAttr = p.GetCustomAttribute<ParameterDataAttribute>();

                if (pAttr?.LongKey == null)
                {
                    @long = $"--{name}";
                }
                else
                {
                    @long = pAttr.LongKey;
                }

                if (pAttr?.ShortKey == null)
                {
                    for (int j = 0; j < name.Length; j++)
                    {
                        int count = 0;

                        foreach (var n in names)
                        {
                            var sym = n?.Skip(j).Take(1).SingleOrDefault();

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
                    @short = pAttr.ShortKey;
                }

                if (pAttr?.Description != null)
                {
                    desc = pAttr.Description;
                }

                arr[i] = new Parameter(name, desc, @long, @short, pos, req, val, def);
            }

            return arr;
        }
    }
}