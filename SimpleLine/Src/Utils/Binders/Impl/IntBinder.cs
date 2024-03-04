using SimpleLineLibrary.Src.Exceptions.BinderExceptions;

namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class IntBinder : IValueBinder<int>
    {
        public int Bind(string value)
        {
            if (int.TryParse(value, out int res))
            {
                return res;
            }
            throw new ConvertException(value, "int");
        }
    }
}
