namespace SimpleLineLibrary.Models
{
	internal class CommandAction
	{
		public IReadOnlyList<Parameter> Parameters { get; }
		
		private readonly Func<object?[]?, object?> _method;

		public CommandAction(Func<object?[]?, object?> func, Parameter[] parameters)
		{
			_method = func;
			Parameters = parameters;
		}

		public object? Invoke(object?[]? args)
		{
			return _method?.Invoke(args);
		}

        public HashSet<string> GetAvalibleKeys()
        {
            var keys = new HashSet<string>();

            for (int i = 0; i < Parameters.Count; i++)
            {
                keys.Add(Parameters[i].LongKey);
                keys.Add(Parameters[i].ShortKey);
            }

            return keys;
        }
    }
}