using SimpleLineLibrary.Extensions;

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
				return _parameters.AsReadOnly();
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
            /*if (obj is Handler other)
			{				 
				if (other.HasKey && this.HasKey)
				{
					return other.Key.IsEqualsTokenName(this.Key);
				}

				if(other.Parameters.Count == 0 || this.Parameters.Count == 0)
				{
					return other.Parameters.Count == this.Parameters.Count;
				}

				var otherKeys = new HashSet<string>();

				if(other.HasKey)
				{
					otherKeys.Add(other.Key);
				}

				foreach (var p in other.Parameters)
				{
					otherKeys.Add(p.LongKey);
					otherKeys.Add(p.ShortKey);
				}


				if(this.HasKey)
				{
					if (otherKeys.Contains(this.Key))
					{
						return true;
					}
				}

				foreach (var p in this.Parameters)
				{
					if (otherKeys.Contains(p.LongKey))
					{
						return true;
					}

					if (otherKeys.Contains(p.ShortKey))
					{
						return true;
					}
				} 
			}*/
            return obj is Handler other && other.Key.IsEqualsTokenName(this.Key);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Key);
		}
    }
}