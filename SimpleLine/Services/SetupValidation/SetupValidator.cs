using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Setup;
using System.Reflection;
using SimpleLineLibrary.Extentions;
using SimpleLineLibrary.Exceptions;

namespace SimpleLineLibrary.Services.SetupValidation
{
    internal class SetupValidator
    {
        public IEnumerable<Exception> Validate(IEnumerable<TypeInfo> types)
        {
            foreach (var t in types.Where(x => x.IsClass))
            {
                var comAttr = t.GetCustomAttribute<CommandAttribute>();

                if (comAttr != null)
                {
                    var tokens = comAttr.Command.SplitOnTokens(' ');

                    foreach (var defToken in tokens)
                    {
                        if (!defToken.IsTokenName())
                        {
                            yield return new ArgumentException($"Invalid token name {defToken}");
                        }
                    }
                }
                else
                {
                    continue;
                }


                MethodInfo? method = null;
                foreach (var m in t.GetMethods())
                {
                    if (m.GetCustomAttribute<CommandActionAttribute>() != null)
                    {
                        if (method != null)
                        {
                            yield return new Exception($"Multiply {nameof(CommandActionAttribute)} use in command class");                            
                        }
                       
                        if (m.IsAbstract)
                        {
                            yield return new NotSupportedException("Abstract method is not supported");
                        }
                        if (m.IsConstructor)
                        {
                            yield return new NotSupportedException("Constructor method is not supported");
                        }
                        if (m.IsGenericMethod)
                        {
                            yield return new NotSupportedException("Generic method is not supported");
                        }

                        method = m;
                    }
                }

                if(method != null)
                {
                    foreach(var p in method.GetParameters())
                    {
                        var pAttr = p.GetCustomAttribute<ParameterDataAttribute>();

                        if (pAttr != null)
                        {
                            if(pAttr.Description?.IsValidText() is false)
                            {
                                yield return new ArgumentException($"Invalid text {pAttr.Description}. Message:");
                            }
                            if(pAttr.LongKey?.IsLongKeyTokenName() is false)
                            {
                                yield return new ArgumentException($"Invalid token {pAttr.LongKey}. Message:");
                            }
                            if(pAttr.ShortKey?.IsShortKeyTokenName() is false)
                            {
                                yield return new ArgumentException($"Invalid token {pAttr.ShortKey}. Message:");
                            }

                            if(pAttr.PermissibleValues == null)
                            {
                                continue;
                            }

                            foreach (var pv in pAttr.PermissibleValues)
                            {
                                pv.ThrowIfWrongText();
                            }
                        }
                    }
                }


                var helpAttrs = t.GetCustomAttributes<HelpBlockAttribute>();
                if (helpAttrs != null)
                {
                    foreach(var h in helpAttrs)
                    {
                        if(!h.Header.IsValidText())
                        {
                            yield return new ArgumentException($"Invalid text: {h.Header}");
                        }

                        if(!h.Body.IsValidText())
                        {
                            yield return new ArgumentException($"Invalid text: {h.Body}");
                        }
                    }
                }                
            }
        }
    }
}
