namespace SimpleLineLibrary.Src.Utils.Binders
{
    public class IntBinder : IValueBinder<int>
    {
        public int Bind(string value)
        {
            return int.Parse(value);
        }
    }
}
