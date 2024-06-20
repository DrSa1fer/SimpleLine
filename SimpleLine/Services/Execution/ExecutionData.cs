using SimpleLineLibrary.Extentions.Strings;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.Parsing.Arguments;

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

        private readonly IReadOnlyList<Argument> _args;
        private readonly HashSet<string> _keys;

        public ExecutionData(IReadOnlyList<Argument> args)
        {
            _args = args;
            _keys = new();

            for(int i = 0; i < _args.Count; i++)
            {
                if (!_args[i].HasKey())
                {
                    continue;
                }
                if (_keys.Contains(_args[i].Key))
                {
                    continue;
                }
                _keys.Add(_args[i].Key);
            }
        }

        public int CountOfArgs()
        {
            var set = new HashSet<string>();
            int count = 0;

            foreach (var arg in _args)
            {
                if (arg.HasKey())
                {
                    if (!set.Contains(arg.Key))
                    {
                        set.Add(arg.Key);
                    }
                }
                else
                {
                    count++;
                }               
            }

            return set.Count + count;
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

            Console.WriteLine( string.Join(", ", values));

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

        public bool Ensure(bool @throw)
        {
            if (@throw)
            {

            }
            return false;
        }
    }
}