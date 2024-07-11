using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.Execution
{
    internal class ExecutionData
    {
        public IReadOnlySet<string> Keys
        {
            get
            {
                return _namedArgs.Keys.ToHashSet();
            }
        }

        public int ArgCount
        {
            get
            {
                return _posedArgs.Count + _namedArgs.Count;
            }
        }

        private readonly IReadOnlyDictionary<int, ICollection<string>> _posedArgs;
        private readonly IReadOnlyDictionary<string, ICollection<string>> _namedArgs;

        public ExecutionData(
            Dictionary<string, ICollection<string>> named,
            Dictionary<int, ICollection<string>> posed)
        {
            _namedArgs = named;
            _posedArgs = posed;
        }

        public string GetValue(Parameter parameter)
        {
            return GetValues(parameter).Single();
        }

        public IEnumerable<string> GetValues(Parameter parameter)
        {
            var ls = new List<string>(ArgCount / 2);

            if (_namedArgs.ContainsKey(parameter.LongKey))
            {
                var value = _namedArgs[parameter.LongKey];
                ls.AddRange(value);
            }

            if (_namedArgs.ContainsKey(parameter.ShortKey))
            {
                var value = _namedArgs[parameter.ShortKey];
                ls.AddRange(value);
            }

            if (_posedArgs.ContainsKey(parameter.Position))
            {
                var value = _posedArgs[parameter.Position];
                ls.AddRange(value);
            }

            if (ls.Any(x => x is null || x.Length < 1))
            {
                throw new ArgumentException("Empty value");
            }

            return ls;
        }

        public bool HasParameter(Parameter parameter)
        {
            return false
                || _namedArgs.ContainsKey(parameter.LongKey)
                || _namedArgs.ContainsKey(parameter.ShortKey)
                || _posedArgs.ContainsKey(parameter.Position)
            ;
        }

        public bool HasValue(Parameter parameter)
        {
            return false
                || _namedArgs.TryGetValue(parameter.LongKey, out var l)
                    && l.Any(x => x is not null && x.Length > 0)
                || _namedArgs.TryGetValue(parameter.ShortKey, out var s)
                    && s.Any(x => x is not null && x.Length > 0)
                || _posedArgs.TryGetValue(parameter.Position, out var p)
                    && p.Any(x => x is not null && x.Length > 0)
            ;
        }
    }
}