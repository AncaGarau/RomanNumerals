using System;
using System.Text.RegularExpressions;
using NumeralConversion;

namespace TextManipulation
{
	public class IntegerSubstitutionService : ISubstitutionService
	{
		private readonly INumeralConverter<int, string> converter;
		private readonly string integerPattern;

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
					Console.WriteLine(e);
					throw;
				}
			});

			return new SubstitutionResult(text, replacementCounter);
		}
	}
}
