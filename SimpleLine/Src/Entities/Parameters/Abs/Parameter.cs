using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Parameters.Abs
{
    public abstract class Parameter<T>
    {
        public Parameter(string[] aliasses, bool isrequired = true)
        {
            _aliasses = new(aliasses);
            IsRequired = isrequired;
        }

        public IReadOnlySet<string> Aliasses => _aliasses;
        public bool IsRequired { get; }
        protected string _value = "";


        private readonly HashSet<string> _aliasses;

        internal T GetValue(InputData data)
        {            
            var i = data.Items.FindIndex(Aliasses.Contains);

            if (i == -1)
            {
                return OnNotFound();                               
            }

            var items = data.Items;

            if (i + 1 == items.Count
                | IsValueParameter(items[i + 1])
                | IsKeyParameter(items[i + 1])) 
            {
                return OnWithoutValue();
            }

            return OnWithValue(items[i + 1]);
        }

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