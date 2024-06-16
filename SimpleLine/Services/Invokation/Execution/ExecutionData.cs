using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Models.Data;

namespace SimpleLineLibrary.Services.Invokation.Execution
{
    internal class ExecutionData
    {
        private readonly IReadOnlyList<Argument> _args;
        private Dictionary<string, Argument> _dict;

        public ExecutionData(IReadOnlyList<Argument> args)
        {
            _args = args;
            _dict = new();

            foreach(var arg in _args)
            {
                if(arg.HasKey())
                {
                    _dict[arg.Key] = arg;
                }
            }
        }

        public string GetValue(Parameter parameter)
        {            
            return GetValues(parameter).Single();
        }     
        
        public IEnumerable<string> GetValues(Parameter parameter)
        {
            var values = _args
                .Where(x => x.HasKey())
                .Where(x =>
                    x.Key.IsEqualsTokenName(parameter.LongKey) ||
                    x.Key.IsEqualsTokenName(parameter.ShortKey))
                .Select(x => x.Value);

            if(true 
                && parameter.Position > -1 
                && parameter.Position < _args.Count 
                && !_args[parameter.Position].HasKey())
            {
                return values.Append(_args[parameter.Position].Value);
            }

            return values;
        }

        public bool HasParameter(Parameter parameter) 
        {
            return 
                _dict.ContainsKey(parameter.LongKey)  || 
                _dict.ContainsKey(parameter.ShortKey) || 
                (
                    parameter.Position > -1 && 
                    parameter.Position < _args.Count && 
                    _args[parameter.Position].HasKey() == false
                );
        }

        public bool HasValue(Parameter parameter)
        {
            return 
                _dict.TryGetValue(
                    parameter.LongKey,
                    out Argument? a1) && a1.HasValue() || 
                _dict.TryGetValue(
                    parameter.ShortKey,
                    out Argument? a2) && a2.HasValue() || 
                (
                    parameter.Position > -1 &&
                    parameter.Position < _args.Count &&
                    _args[parameter.Position].HasKey() == false &&
                    _args[parameter.Position].HasValue()
                );
        }
    }
}