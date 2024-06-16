namespace SimpleLineLibrary.Models.Info
{
    public class ParameterInfo : BaseInfo
    {
        public const string KEY_SEPARATOR = " | ";
        public const string REQUIRED = "[REQUIRED]";
        public const string OPTIONAL = "[OPTIONAL]";

        private readonly string _name;
        private readonly string _description;
        private readonly string _shortKey;
        private readonly string _longKey;
        private readonly bool _isRequired;
        private readonly Type _valueType;

        private readonly bool _hasDefaultValue;
        private readonly string _defaultValue;

        internal ParameterInfo(Parameter parameter)
        {
            _name = parameter.Name;
            _description = parameter.Description;
            _shortKey = parameter.ShortKey;
            _longKey = parameter.LongKey;
            _isRequired = parameter.IsRequired;
            _valueType = parameter.ValueType;

            _hasDefaultValue = parameter.HasDefaultValue;
            _defaultValue = parameter.DefaultValue?.GetType().Name ?? "";
        }

        public override string ToString()
        {
            return "";

            //return $"[{r}] {_shortKey}|{_longKey} <{_valueType}> - {Description}";
        }
    }
}