namespace SimpleLineLibrary.Models
{
	internal delegate object? HandlerAction(object?[]? obj);

    internal class Handler
	{     
        public IReadOnlyList<Parameter> Parameters { get; }
		public IReadOnlySet<string> AvalibleKeys { get; }

        private readonly HandlerAction _method;

		public Handler(HandlerAction func, Parameter[] parameters)
		{
			_method = func;
			var keys = new HashSet<string>();

			for(int i = 0; i < parameters.Length; i++)
			{
				keys.Add(parameters[i].LongKey);
				keys.Add(parameters[i].ShortKey);
            }

			Parameters = parameters;
			AvalibleKeys = keys;
		}

		public object? Invoke(object?[]? args)
		{
			return _method?.Invoke(args);
		}
    }
}