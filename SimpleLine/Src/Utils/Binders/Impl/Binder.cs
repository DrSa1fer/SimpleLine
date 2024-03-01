namespace SimpleLineLibrary.Src.Utils.Binders.Impl
{
    public class StringBinder : IValueBinder<string>
    {
        public string Bind(string value)
        {
            return value;
        }
    }
}
