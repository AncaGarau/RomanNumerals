using System;
using System.Linq;
using System.Text;

namespace NumeralConversion
{
	public class ArabicToRomanConverter : INumeralConverter<int, string>
	{
		public string Convert(int input)
		{
			GuardAgainstInvalidInput(input);

			return GenerateRomanNumeral(input);
		}

		private static string GenerateRomanNumeral(int input)
		{
			var romanNumeralBuilder = new StringBuilder();

			foreach (var romanSymbol in RomanSymbolsProvider.GetRomanSymbols)
			{
				var timesToAppend = input / romanSymbol.Key;
				input = input - timesToAppend * romanSymbol.Key;
				var currentNumeral = string.Concat(Enumerable.Repeat(romanSymbol.Value, timesToAppend));
				romanNumeralBuilder.Append(currentNumeral);
			}

			return romanNumeralBuilder.ToString();
		}

		private void GuardAgainstInvalidInput(int input)
		{
			if (input < 1 || input > 3999)
				throw new ArgumentException("The number to be converted to a roman numeral is out of the accepted range! ", nameof(input));
		}
	}
}
