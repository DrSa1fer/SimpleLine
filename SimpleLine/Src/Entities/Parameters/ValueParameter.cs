using SimpleLineLibrary.Src.Entities.Parameters.Abs;
using SimpleLineLibrary.Src.Exceptions.ParameterExceptions;
using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters
{
    public class ValueParameter<T> : Parameter<T>
    {
        public ValueParameter
            (string[] aliasses, IValueBinder<T> binder, string? defaultValue, bool isrequired)
            : base(aliasses, isrequired)
        {
            _binder = binder;            
            DefaultValue = defaultValue ?? "";
        }

        public string DefaultValue { get; }

        private readonly IValueBinder<T> _binder;

        protected override T OnNotFound()
        {
            if (IsRequired)
            {
                throw new ParameterNotFoundException(string.Join("&", Aliasses));                
            }
            return _binder.Bind(DefaultValue);
        }
        protected override T OnWithoutValue()
        {
            throw new ParameterWithoutValueException(string.Join("&", Aliasses));
        }
        protected override T OnWithValue(string value)
        {
            return _binder.Bind(value);
        }
    }
}