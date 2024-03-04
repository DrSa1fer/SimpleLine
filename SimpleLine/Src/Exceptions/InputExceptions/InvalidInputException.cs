namespace SimpleLineLibrary.Src.Exceptions.InputExceptions
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
