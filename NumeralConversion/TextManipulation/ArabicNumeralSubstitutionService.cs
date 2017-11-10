using System.Text.RegularExpressions;
using NumeralConversion;

namespace TextManipulation
{
	public class ArabicNumeralSubstitutionService : ISubstitutionService
	{
		private readonly INumeralConverter<int, string> converter;

		public ArabicNumeralSubstitutionService(INumeralConverter<int, string> converter)
		{
			this.converter = converter;
		}

		public SubstitutionResult Substitute(string text)
		{
			var arabicNumerals = Regex.Matches(text, @"\d+");

			foreach (Match match in arabicNumerals)
			{
				var romanNumeral = converter.Convert(int.Parse(match.Value));
				text = text.Replace(match.Value, romanNumeral);
			}

			return new SubstitutionResult(text, arabicNumerals.Count);
		}
	}
}
