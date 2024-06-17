using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.Parsing.Arguments;

namespace SimpleLineLibrary.Services.Execution
{
    internal class ExecutionData
    {
        private readonly IReadOnlyList<Argument> _args;

        public ExecutionData(IReadOnlyList<Argument> args)
        {
            _args = args;
        }

        public string GetValue(Parameter parameter)
        {
            return GetValues(parameter).Single();
        }

        public IEnumerable<string> GetValues(Parameter parameter)
        {
            var values = _args
                .Where(x => x.HasKey())
                .Where(x => x.Key.IsEqualsTokenName(parameter.LongKey) ||
                    x.Key.IsEqualsTokenName(parameter.ShortKey))
                .Select(x => x.Value);

            if (true
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
            return _args
                .Where(x => x.HasKey())
                .Any(x => 
                    x.Key.IsEqualsTokenName(parameter.LongKey) ||
                    x.Key.IsEqualsTokenName(parameter.ShortKey)) ||
                    
                    (parameter.Position > -1 &&
                    parameter.Position < _args.Count &&
                    _args[parameter.Position].HasKey() == false)
                ;
        }

        public bool HasValue(Parameter parameter)
        {
            return _args
                .Where(x => x.HasKey())
                .Any(x => (
                    x.Key.IsEqualsTokenName(parameter.LongKey) ||
                    x.Key.IsEqualsTokenName(parameter.ShortKey)) && 
                    x.HasValue()) ||

                    (parameter.Position > -1 &&
                    parameter.Position < _args.Count &&
                    _args[parameter.Position].HasKey() == false &&
                    _args[parameter.Position].HasValue())
                ;
        }
    }
}