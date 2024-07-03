using SimpleLineLibrary.Services.CommandParsing.Activation.Exceptions;

namespace SimpleLineLibrary.Services.CommandParsing.Activation
{
    internal class DIActivator
    {
        private IReadOnlyDictionary<Type, Func<object?>> _types;

        public DIActivator(IReadOnlyDictionary<Type, Func<object?>> types)
        {
            _types = types;
        }

        public object? CreateInstance(Type type)
        {
            foreach(var ctor in type.GetConstructors())
            {
                var eReq = ctor.GetParameters().Where(x => !x.IsOptional);
                
                if (eReq.All(p => _types.ContainsKey(p.ParameterType)))
                {
                    var aReq = eReq.ToArray();
                    var args = new object?[aReq.Length];

                    for (int i = 0; i < args.Length; i++)
                    {
                        args[i] = _types[aReq[i].ParameterType].Invoke();
                    }
                    
                    return ctor.Invoke(args);
                }
            }

            throw new CtorNotFoundException(type);
        }
    }
}