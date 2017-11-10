using System.Collections.Generic;

namespace NumeralConversion
{
	internal class RomanSymbolsProvider
	{
		public static IEnumerable<KeyValuePair<int, string>> GetRomanSymbols()
		{
			yield return new KeyValuePair<int, string>(1000, "M");
			yield return new KeyValuePair<int, string>(900, "CM");
			yield return new KeyValuePair<int, string>(500, "D");
			yield return new KeyValuePair<int, string>(400, "CD");
			yield return new KeyValuePair<int, string>(100, "C");
			yield return new KeyValuePair<int, string>(90, "XC");
			yield return new KeyValuePair<int, string>(50, "L");
			yield return new KeyValuePair<int, string>(40, "XL");
			yield return new KeyValuePair<int, string>(10, "X");
			yield return new KeyValuePair<int, string>(9, "IX");
			yield return new KeyValuePair<int, string>(5, "V");
			yield return new KeyValuePair<int, string>(4, "IV");
			yield return new KeyValuePair<int, string>(1, "I");
		}
	}
}
