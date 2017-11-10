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

				if(timesToAppend.Equals(0))
					continue;

				var currentNumeral = string.Concat(Enumerable.Repeat(romanSymbol.Value, timesToAppend));
				romanNumeralBuilder.Append(currentNumeral);

				var newInput = input - timesToAppend * romanSymbol.Key;
				if(input.ToString().Length -newInput.ToString().Length >= 1)
					romanNumeralBuilder.Append(" ");

				input = newInput;
			}

			return romanNumeralBuilder.ToString().TrimEnd();
		}

		private void GuardAgainstInvalidInput(int input)
		{
			if (input < 1 || input > 3999)
				throw new ArgumentException("The number to be converted to a roman numeral is out of the accepted range! ", nameof(input));
		}
	}
}
