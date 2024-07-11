namespace SimpleLineLibrary.Extentions.Exceptions
{
    internal class InvalidTextException : Exception
    {
        public InvalidTextException(int curCount, int maxCount)
            : base($"Invalid text. Message: count {curCount} must be less or equals {maxCount}")
        {

        }
    }
}