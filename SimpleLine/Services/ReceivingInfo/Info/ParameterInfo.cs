using SimpleLineLibrary.Models;

namespace SimpleLineLibrary.Services.ReceivingInfo.Info
{
    internal class ParameterInfo : BaseInfo
    {
        public const string REQUIRED = "[REQUIRED]";
        public const string OPTIONAL = "[OPTIONAL]";

        internal string Name { get; }
        internal string Description { get; }
        internal string ShortKey { get; }
        internal string LongKey { get; }
        internal bool IsRequired { get; }
        internal Type ValueType { get; }

        internal bool HasDefaultValue { get; }
        internal string DefaultValue { get; }

        internal ParameterInfo(Parameter parameter, string program, string vers)
            : base(program, vers)
        {
            Name = parameter.Name;
            Description = parameter.Description;
            ShortKey = parameter.ShortKey;
            LongKey = parameter.LongKey;
            IsRequired = parameter.IsRequired;
            ValueType = parameter.ValueType;

            HasDefaultValue = parameter.HasDefaultValue;
            DefaultValue = parameter.DefaultValue?.GetType().Name ?? "";
        }

        public override string ToString()
        {
            return "";

            //return $"[{r}] {_shortKey}|{_longKey} <{_valueType}> - {Description}";
        }
    }
}