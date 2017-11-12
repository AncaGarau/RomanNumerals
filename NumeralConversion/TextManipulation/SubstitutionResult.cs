namespace TextManipulation
{
	public class SubstitutionResult
	{
		public string ResultedText { get; }
		public int NumberOfSubstitutions { get; }

		public SubstitutionResult(string resultedText, int numberOfSubstitutions)
		{
			ResultedText = resultedText;
			NumberOfSubstitutions = numberOfSubstitutions;
		}
	}
}
