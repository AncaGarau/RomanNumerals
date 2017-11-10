using System.Linq;
using System.Text;

namespace NumeralConversion
{
	public class ArabicToRomanConverter : INumeralConverter<int, string>
	{
		public string Convert(int input)
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
	}
}
