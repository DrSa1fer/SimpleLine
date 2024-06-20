using SimpleLineLibrary.Services.Parsing.Arguments;
using SimpleLineLibrary.Extentions.Strings;
using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Execution
{
    internal class ExecutionData
    {
        public IReadOnlySet<string> Keys
        {
            get
            {
                return _keys;
            }
        }

        public int ArgCount
        {
            get
            {
                return _notNamedCount + _keys.Count;
            }
        }

        private readonly IReadOnlyList<Argument> _args;
        private readonly HashSet<string> _keys;
        private readonly int _notNamedCount;

        public ExecutionData(IReadOnlyList<Argument> args)
        {
            _args = args;
            _keys = new();

            for(int i = 0; i < _args.Count; i++)
            {
                if (!_args[i].HasKey())
                {
                    _notNamedCount++;
                    continue;
                }
                if (_keys.Contains(_args[i].Key))
                {
                    continue;
                }
                _keys.Add(_args[i].Key);
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
                .Where(x => x.Key.IsEqualsToken(parameter.LongKey) ||
                    x.Key.IsEqualsToken(parameter.ShortKey))
                .Select(x => x.Value);

            if (true
                && parameter.Position > -1
                && parameter.Position < _args.Count
                && !_args[parameter.Position].HasKey())
            {
                return values.Append(_args[parameter.Position].Value);
            }

            Console.WriteLine( string.Join(", ", values));

            return values;
        }
        public bool HasParameter(Parameter parameter)
        {
            return _args
                .Where(x => x.HasKey())
                .Any(x => 
                    x.Key.IsEqualsToken(parameter.LongKey) ||
                    x.Key.IsEqualsToken(parameter.ShortKey)) ||
                    
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
                    x.Key.IsEqualsToken(parameter.LongKey) ||
                    x.Key.IsEqualsToken(parameter.ShortKey)) && 
                    x.HasValue()) ||

                    (parameter.Position > -1 &&
                    parameter.Position < _args.Count &&
                    _args[parameter.Position].HasKey() == false &&
                    _args[parameter.Position].HasValue())
                ;
        }
    }
}