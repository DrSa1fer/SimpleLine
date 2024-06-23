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
                return _pos.Count + _keys.Count;
            }
        }

        private readonly IReadOnlyList<Argument> _args;
        private readonly HashSet<string> _keys;
        private readonly HashSet<int> _pos;

        public ExecutionData(IReadOnlyList<Argument> args)
        {
            _args = args;
            _keys = new();
            _pos = new();

            for(int i = 0; i < _args.Count; i++)
            {
                var pos = _args[i].Position;
                var key = _args[i].Key;
                
                if(_args[i].HasKey())
                {
                    if (pos != -1)
                    {
                        throw new ArgumentException("Argument cant have pos and key");
                    }
                    if (!_keys.Contains(key))
                    {
                        _keys.Add(key);                    
                    }
                }
                else
                {
                    if (pos < 0)
                    {
                        throw new ArgumentException("Position must bigger than -1");
                    }
                    if (!_pos.Contains(pos))
                    {                 
                        _pos.Add(pos);                    
                    }
                }
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
                .Select(x => x.Value)
            ;
        }
        public bool HasParameter(Parameter parameter)
        {
            return false
                || _pos.Contains(parameter.Position)
                || _keys.Contains(parameter.LongKey)
                || _keys.Contains(parameter.ShortKey)
            ;
        }
        public bool HasValue(Parameter parameter)
        {
            return _args
                .Where(x => false 
                    || x.Key.IsEqualsToken(parameter.LongKey) 
                    || x.Key.IsEqualsToken(parameter.ShortKey) 
                    || x.Position == parameter.Position)
                .Any(x => x.HasValue())
            ;
        }
    }
}