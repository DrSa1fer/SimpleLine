namespace SimpleLineLibrary.Services.Logging
{
    internal abstract class BaseLogger
    {
        public abstract void WriteMessage(string? data);
        public abstract void WriteError(string? data);
    }
}