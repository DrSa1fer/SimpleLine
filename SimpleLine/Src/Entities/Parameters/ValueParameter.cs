using SimpleLineLibrary.Src.Entities.Parameters.Abs;
using SimpleLineLibrary.Src.Exceptions.ParameterExceptions;
using SimpleLineLibrary.Src.Execution;
using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters
{
    public class ValueParameter<T> : Parameter<T>
    {
        public ValueParameter
            (string[] aliasses, IValueBinder<T> binder, T defaultValue, string helpInfo)
            : base(false, helpInfo)
        {
            _aliasses = aliasses;
            _binder = binder;            
            DefaultValue = defaultValue;
        }

        public ValueParameter(
            string[] aliasses, IValueBinder<T> binder, string helpInfo) 
            : base(true, helpInfo)
        {
            _aliasses = aliasses;
            _binder = binder;
            DefaultValue = default!;
        }
        public IReadOnlySet<string> Aliasses => new HashSet<string>(_aliasses);
        public T DefaultValue { get; }

        private readonly string[] _aliasses;
        private readonly IValueBinder<T> _binder;

        protected override T OnNotFound()
        {
            if (IsRequired)
            {
                throw new ParameterNotFoundException(string.Join("&", _aliasses));                
            }
            return DefaultValue;
        }
        protected override T OnWithoutValue()
        {
            throw new ParameterWithoutValueException(string.Join("&", _aliasses));
        }
        protected override T OnWithValue(string value)
        {
            return _binder.Bind(value);
        }

        protected override int GetIndex(InputData data)
        {
            var set = new HashSet<string>();
            foreach(var i in _aliasses)
            {
                set.Add($"--{i}");
            }
            return data.Items.FindIndex(set.Contains);
        }
    }
}