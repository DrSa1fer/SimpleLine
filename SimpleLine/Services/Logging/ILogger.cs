namespace SimpleLineLibrary.Services.Logging
{
    internal interface ILogger
    {
        void WriteMessage(string? data);
        void WriteError(string? data);
    }
}