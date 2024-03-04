namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class StringBinder : IValueBinder<string>
    {
        public string Bind(string value)
        {
            return value;
        }
    }
}
