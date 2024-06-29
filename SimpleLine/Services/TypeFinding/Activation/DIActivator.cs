using SimpleLineLibrary.Services.TypeFinding.Activation.Exceptions;

namespace SimpleLineLibrary.Services.TypeFinding.Activation
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
            var ctor = type.GetConstructors()
                .FirstOrDefault(x => x.GetParameters().All(p => _types.ContainsKey(p.ParameterType))) 
                ?? throw new CtorNotFoundException(type)
            ;

            var ps = ctor.GetParameters();
            var args = new object?[ps.Length];

            for(int i = 0; i < args.Length; i++) 
            {
                args[i] = _types[ps[i].ParameterType].Invoke();
            }
                        
            return ctor.Invoke(args);
        }
    }
}