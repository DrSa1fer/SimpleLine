using SimpleLineLibrary.Src.Utils.Binders;

namespace SimpleLineLibrary.Src.Entities.Parameters.Impl
{
    public class IntParameter : ValueParameter<int>
    {
        public IntParameter(string[] aliasses, int defaultValue, string helpInfo)
            : base(aliasses, new IntBinder(), defaultValue, helpInfo)
        {
        }

        public IntParameter(string[] aliasses, string helpInfo)
            : base(aliasses, new IntBinder(), helpInfo)
        {
        }
    }
}