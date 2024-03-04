using SimpleLineLibrary.Src.Entities.Parameters.Info;
using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Parameters.Abs
{
    public abstract class Parameter<T>
    {
        public Parameter(bool isrequired, string helpInfo)
        {
            IsRequired = isrequired;
            ParameterInfo = new ParameterInfo(helpInfo);
        }
        public bool IsRequired { get; }
        public ParameterInfo ParameterInfo { get; }

        internal T GetValue(InputData data)
        {            
            var i = GetIndex(data);

            if (i == -1)
            {
                return OnNotFound();                               
            }

            var items = data.Items ?? new();

            if (i + 1 >= items.Count)
            {
                return OnWithoutValue();
            }
            
            if (IsValueParameter(items[i + 1])
                | IsKeyParameter(items[i + 1]))
            {
                return OnWithoutValue();
            }

            return OnWithValue(items[i + 1]);
        }

        protected abstract int GetIndex(InputData data);
        protected abstract T OnNotFound();
        protected abstract T OnWithoutValue();
        protected abstract T OnWithValue(string value);

        public static bool IsValueParameter(string name)
        {
            return name.Trim().StartsWith("-");
        }
        public static bool IsKeyParameter(string name)
        {
            return name.Trim().StartsWith("/");
        }
    }
}