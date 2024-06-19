using SimpleLineLibrary.Utils.Strings;

namespace SimpleLineLibrary.Models
{
    internal delegate object? HandlerAction(object?[]? obj);

    internal class Handler : BaseEntity
	{
		public string Key
		{
			get
			{
				return _key;
			}
		}

		public bool HasKey
		{
			get
			{
				return Key is not null && Key.Length > 0;
			}
		}        

        public IReadOnlyList<Parameter> Parameters
		{
			get 
			{
				return _parameters;
			}
		}

		private readonly string _key;
		
		private readonly Parameter[] _parameters;

        private readonly HandlerAction _method;

		public Handler(string name, string desc, string key, HandlerAction func, Parameter[] parameters)
			: base(name, desc)
		{
			_key = key;

			_method = func;
			_parameters = parameters;
		}

		public object? Invoke(object?[]? args)
		{
			return _method?.Invoke(args);
		}

		public override bool Equals(object? obj)
		{
            return obj is Handler other && other.Key.IsEqualsTokenName(this.Key);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Key);
		}
    }
}