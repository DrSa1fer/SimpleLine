namespace SimpleLineLibrary.Models
{
	internal delegate object? HandlerAction(object?[]? obj);

    internal class Handler
	{     
        public IReadOnlyList<Parameter> Parameters
		{
			get 
			{
				return _parameters;
			}
		}

		public IReadOnlySet<string> AvalibleKeys
		{
			get
			{
				return _keys;
			}
		}

		private readonly HashSet<string> _keys;
		private readonly Parameter[] _parameters;
        private readonly HandlerAction _method;

		public Handler(HandlerAction func, Parameter[] parameters)
		{
			_parameters = parameters;
			_method = func;
			_keys = new();

			for(int i = 0; i < parameters.Length; i++)
			{
				_keys.Add(_parameters[i].LongKey);
				_keys.Add(_parameters[i].ShortKey);
            }
		}

		public object? Invoke(object?[]? args)
		{
			return _method?.Invoke(args);
		}
    }
}