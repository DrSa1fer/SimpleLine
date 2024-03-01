using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class IntParameter : ValueParameter<int>
    {
        public IntParameter(params string[] aliasses)
            : base(aliasses, new IntBinder(), true, "0")
        {
        }
    }
}