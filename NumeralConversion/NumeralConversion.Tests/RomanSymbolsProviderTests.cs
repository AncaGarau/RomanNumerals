 using NUnit.Framework;

namespace NumeralConversion.Tests
{
	[TestFixture]
	internal class RomanSymbolsProviderTests
	{
		[Test]
		public void Should_provide_13_known_values_for_roman_numerals()
		{
			var numerals = RomanSymbolsProvider.GetRomanSymbols;

			Assert.AreEqual(numerals.Count, 13);
		}

		[Test]
		[TestCase(1000, "M")]
		[TestCase(900, "CM")]
		[TestCase(500, "D")]
		[TestCase(400, "CD")]
		[TestCase(100, "C")]
		[TestCase(90, "XC")]
		[TestCase(50, "L")]
		[TestCase(40, "XL")]
		[TestCase(10, "X")]
		[TestCase(9, "IX")]
		[TestCase(5, "V")]
		[TestCase(4, "IV")]
		[TestCase(1, "I")]
		public void Should_provide_correct_known_value_for_roman_numerals(int arabic, string expectedRoman)
		{
			var numerals = RomanSymbolsProvider.GetRomanSymbols;

			Assert.AreEqual(numerals[arabic], expectedRoman);
		}
	}
}
