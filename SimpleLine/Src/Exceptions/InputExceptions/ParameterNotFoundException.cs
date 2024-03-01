namespace SimpleLineLibrary.Src.Exceptions
{

	[Serializable]
	public class ParameterNotFoundException : Exception
	{		
		public ParameterNotFoundException(string parameterName)
			: base($"Parameter with name \"{parameterName}\" not found in user input data") 
		{
		}
	}
}
