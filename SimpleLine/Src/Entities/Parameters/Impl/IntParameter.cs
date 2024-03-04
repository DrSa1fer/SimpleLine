using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class IntParameter : ValueParameter<int>
    {
        public IntParameter(string[] aliasses, int? defaultValue = null)
            : base(aliasses, new IntBinder(), defaultValue?.ToString(), defaultValue == null)
        {
        }

        public IntParameter(params string[] aliasses)
            : base(aliasses, new IntBinder(), null, true)
        {
        }
    }
}