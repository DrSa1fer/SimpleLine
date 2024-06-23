using SimpleLineLibrary.Services.Parsing.Arguments;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Extentions;

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
            return _args
                .Where(x => false
                    || x.Key.IsEqualsToken(parameter.LongKey) 
                    || x.Key.IsEqualsToken(parameter.ShortKey) 
                    || x.Position == parameter.Position)
                .Select(x => x.Value);
        }
        public bool HasParameter(Parameter parameter)
        {
            return
                _args.Any(x => x.Position == parameter.Position) ||
                _args.Any(x => false
                    || x.Key.IsEqualsToken(parameter.LongKey) 
                    || x.Key.IsEqualsToken(parameter.ShortKey))
                ;
        }
        public bool HasValue(Parameter parameter)
        {
            return _args
                .Where(x => false 
                    || x.Key.IsEqualsToken(parameter.LongKey) 
                    || x.Key.IsEqualsToken(parameter.ShortKey) 
                    || x.Position == parameter.Position)
                .Any(x => x.HasValue());
        }
    }
}