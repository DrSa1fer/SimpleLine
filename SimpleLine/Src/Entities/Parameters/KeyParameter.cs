using SimpleLineLibrary.Src.Exceptions;
using SimpleLineLibrary.Src.Execution;

namespace SimpleLineLibrary.Src.Entities.Parameters
{
    public sealed class KeyParameter : Parameter<bool>
    {
        public KeyParameter(params string[] aliasses) : base(aliasses, false)
        {
        }

        internal override bool GetValue(InputData data)
        {
            if(data.Items.Find(Aliasses.Contains) is not null)
            {
                if(MakeValuesFromData(data)?.Count > 0)
                {
                    throw new KeyValueException();
                }
                return true;
            }
            return false;
        }   
    }
}
