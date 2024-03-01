using SimpleLineLibrary.Src.Exceptions;
using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Parameters
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

        private readonly HashSet<string> _aliasses;

        internal abstract T GetValue(InputData data);
        
        protected ICollection<string> MakeValuesFromData(InputData data)
        {
            var items = data.Items;
            var i = items.FindIndex(Aliasses.Contains);
            if(i == -1)
            {
                if(!IsRequired)
                {
                    return new List<string>();
                }
                throw new ParameterNotFoundException(string.Join(", ", _aliasses));
            }
            var list = new List<string>();

            while(true)
            {
                if (i + 1 == items.Count) break;
                if (items[i + 1].StartsWith('/')) break;
                if (items[i + 1].StartsWith('-')) break;

                list.Add(items[++i]);
            }
            return list;
        }
    }
}