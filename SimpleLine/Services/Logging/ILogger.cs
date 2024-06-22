namespace SimpleLineLibrary.Services.Logging
{
    internal interface ILogger
    {        
        void WriteMessage(string? msg);
        void WriteWarning(string? msg, int level = 0);
        void WriteError(string? msg);
    }
}