using SimpleLineLibrary.Extentions;
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

        private readonly IReadOnlyDictionary<int, IEnumerable<string>> _posedArgs;
        private readonly IReadOnlyDictionary<string, IEnumerable<string>> _namedArgs;

        private ExecutionData(Dictionary<int, IEnumerable<string>> posed, Dictionary<string, IEnumerable<string>> named)
        {
            _posedArgs = posed;
            _namedArgs = named;
        }

        public string GetValue(Parameter parameter)
        {
            return GetValues(parameter).Single();
        }

        public IEnumerable<string> GetValues(Parameter parameter)
        {
            var ls = new List<string>();

            if(_namedArgs.ContainsKey(parameter.LongKey))
            {
                var value = _namedArgs[parameter.LongKey];
                ls.AddRange(value);
            }

            if(_namedArgs.ContainsKey(parameter.ShortKey))
            {
                var value = _namedArgs[parameter.ShortKey];
                ls.AddRange(value);
            }

            if(_posedArgs.ContainsKey(parameter.Position))
            {
                var value = _posedArgs[parameter.Position];
                ls.AddRange(value);
            }

            if(ls.Any(x => x is null || x.Length < 0))
            {
                throw new Exception("Empty value");
            }

            return ls.Where(x => x is not null && x.Length > 0);
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
                || _namedArgs.TryGetValue(parameter.LongKey, out var l) && l.Any(x => x is not null && x.Length > 0)
                || _namedArgs.TryGetValue(parameter.ShortKey, out var s) && s.Any(x => x is not null && x.Length > 0)
                || _posedArgs.TryGetValue(parameter.Position, out var p) && p.Any(x => x is not null && x.Length > 0)
            ;
        }

        public static ExecutionData Build(Queue<string> args)
        {
            var named = new Dictionary<string, List<string>>();
            var posed = new Dictionary<int, List<string>>();

            int pos = 0;

            while (args.Count > 0)
            { 
                if (IsKey(args.Peek()))
                {
                    string key = args.Dequeue();
                    string value = string.Empty;

                    if(args.TryPeek(out string? nextToken))
                    {
                        if (IsEqualSign(nextToken))
                        {
                            args.Dequeue(); //skip '='

                            if (args.TryDequeue(out string? keyValue))
                            {
                                value = keyValue;
                            }
                            else
                            {
                                throw new ArgumentException($"key {key} wait value after '=' ");
                            }
                        }
                        else if (IsValue(nextToken))
                        {
                            value = args.Dequeue();
                        }
                    }
                    
                    if(!named.ContainsKey(key) || named[key] == null)
                    {
                        named[key] = new List<string>();
                    }

                    named[key].Add(value);
                }
                else if(IsValue(args.Peek()))
                {
                    string value = args.Dequeue();

                    if(!posed.ContainsKey(pos) || posed[pos] == null)
                    {
                        posed[pos] = new List<string>();
                    }

                    posed[pos].Add(value);
                }

                if(args.TryPeek(out var combine) && IsCombine(combine))
                {
                    args.Dequeue();
                }
                else
                {
                    pos++;
                }
            }

            var pdict = posed.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value);
            var ndict = named.ToDictionary(x => x.Key, x => (IEnumerable<string>)x.Value);

            return new ExecutionData(pdict, ndict);


            bool IsKey(string token)
            {
                return token.IsKeyTokenName();
            }
            bool IsCombine(string token)
            {
                return token.IsEqualsToken("&");
            }
            bool IsEqualSign(string token)
            {
                return token.IsEqualsToken("=");
            }
            bool IsValue(string token)
            {
                return !IsKey(token) && !IsCombine(token) && !IsEqualSign(token);
            }
        }
    }
}