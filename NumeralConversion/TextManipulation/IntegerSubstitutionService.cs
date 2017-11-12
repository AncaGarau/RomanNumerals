using System;
using System.Text.RegularExpressions;
using NumeralConversion;

namespace TextManipulation
{
	public class IntegerSubstitutionService : ISubstitutionService
	{
		private readonly INumeralConverter<int, string> converter;
		private readonly string integerPattern;

		private const string SubstitutionErrorMessage =
			@"There was an error during the substitution process.
			Please make sure that the pattern is matching integers and that the matched values are compatible with the converter.
			See inner exception for deatils";

		public IntegerSubstitutionService(string integerPattern, INumeralConverter<int, string> converter)
		{
			this.integerPattern = integerPattern;
			this.converter = converter;
		}

		public SubstitutionResult Substitute(string text)
		{
			var replacementCounter = 0;

			text = Regex.Replace(text, integerPattern, match =>
			{
				try
				{
					var replacement = converter.Convert(int.Parse(match.Value.ToString()));
					replacementCounter += 1;
					return replacement;
				}
				catch (Exception e)
				{
					var ex = new Exception(SubstitutionErrorMessage, e);
					throw ex;
				}
			});

			return new SubstitutionResult(text, replacementCounter);
		}
	}
}
