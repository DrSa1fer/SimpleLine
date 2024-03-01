namespace SimpleLineLibrary.Src.Utils.Binders
{
    public interface IValueBinder<T>
    {
        public T Bind(string value);
    }
}