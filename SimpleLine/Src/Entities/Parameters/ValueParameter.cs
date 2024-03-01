using SimpleLineLibrary.Src.Exceptions;
using SimpleLineLibrary.Src.Execution;
using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters
{
    public class ValueParameter<T> : Parameter<T>
    {
        public ValueParameter
            (string[] aliasses, IValueBinder<T> binder, bool isrequired = true, string defaultValue = "")
            : base(aliasses, isrequired)
        {
            _binder = binder;
            DefaultValue = defaultValue;
        }

        public string DefaultValue { get; }

        private readonly IValueBinder<T> _binder;

        internal override T GetValue(InputData data)
        {
            if (MakeValuesFromData(data)?.Count == 0)
            {
                if (!data.Items.Any(Aliasses.Contains))
                {
                    return _binder.Bind(DefaultValue);
                }
                throw new InvalidInputException();
            }
            return _binder.Bind(string.Join(',', MakeValuesFromData(data)!));
        }        
    }
}