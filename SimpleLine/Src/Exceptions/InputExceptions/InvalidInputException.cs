namespace SimpleLineLibrary.Src.Exceptions
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException() 
            : base("Invalid user input")
        {

        }
    }
}
