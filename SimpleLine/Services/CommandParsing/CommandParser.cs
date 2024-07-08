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

                        foreach (var defToken in tokens)
                        {
                            defToken.ThrowIfWrongTokenName();
                        }

                        local = MakeNode(local, tokens);
                    }

                    if (local.Command != null)
                    {
                        throw new ArgumentException("Command already is registered");
                    }

                    local.Command = new Command(local.Uid);
             
                    foreach (var h in t.GetCustomAttributes<HelpBlockAttribute>())
                    {
                        local.Command.AddHelpBlock(new HelpBlock(h.Header, h.Body, h.Order));
                    }

                    MethodInfo? m = null;
                    
                    foreach(var i in t.GetMethods())
                    {
                        if(i.GetCustomAttribute<CommandActionAttribute>() != null)
                        {
                            if(m == null)
                            {
                                m = i;
                                continue;
                            }

                            throw new InvalidOperationException($"Multiply {nameof(CommandActionAttribute)} use in command class");
                        }
                    }

                    local.Command.AddHelpBlock(new SubcommandBlock(local));

                    if (m == null)
                    {
                        local.Command.AddHelpBlock(new UsageBlock(local, "[COMMANDS] [OPTIONS] <ARGS>"));
                        //TODO
                        continue;
                    }

                    //Validation
                    if (m.IsAbstract)
                    {
                        throw new NotSupportedException("Abstract method is not supported");
                    }
                    if (m.IsConstructor)
                    {
                        throw new NotSupportedException("Constructor method is not supported");
                    }
                    if (m.IsGenericMethod) 
                    {
                        throw new NotSupportedException("Generic method is not supported");
                    }

                    var obj = m.IsStatic ? null : _activator.CreateInstance(t);

                    var fn = new Func<object?[]?, object?>(x => m.Invoke(obj, x));
                    var ps = MakeParameters(m.GetParameters());

                    local.Command.Action = new CommandAction(fn, ps);

                    //TODO
                    local.Command.AddHelpBlock(new UsageBlock(local, "[OPTIONS] <ARGS>"));                    
                    local.Command.AddHelpBlock(new OptionBlock(local.Command));
                }
                
                return root;
            }
            catch(Exception e)
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

                if(pAttr?.LongKey == null)
                {
                    @long = $"--{name}";
                }
                else
                {
                    @long = pAttr.LongKey;
                }

                if(pAttr?.ShortKey == null)
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

                @long.ThrowIfWrongLongKeyTokenName();
                @short.ThrowIfWrongShortKeyTokenName();

                arr[i] = new Parameter(name, desc, @long, @short, pos, req, val, def);
            }

            return arr;
        }
    }
}