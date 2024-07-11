namespace SimpleLineLibrary.Models
{
    internal class CommandAction
    {
        public Func<object?[]?, object?> Method { get; }
        public IReadOnlyList<Parameter> Parameters { get; }

        public IReadOnlySet<string> AvalibleKeys => _chachedKeys ??= GetAvalibleKeys();

        private IReadOnlySet<string>? _chachedKeys;

        public CommandAction(Func<object?[]?, object?> func, IReadOnlyList<Parameter> parameters)
        {
            Method = func;
            Parameters = parameters;
        }

        private HashSet<string> GetAvalibleKeys()
        {
            var keys = new HashSet<string>();

            foreach (var p in Parameters)
            {
                keys.Add(p.LongKey);
                keys.Add(p.ShortKey);
            }

            return keys;
        }
    }
}