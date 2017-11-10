 using System.Linq;
 using NUnit.Framework;

namespace NumeralConversion.Tests
{
	[TestFixture]
	internal class RomanSymbolsProviderTests
	{
		[Test]
		public void Should_provide_13_known_values_for_roman_numerals()
		{
			var numerals = RomanSymbolsProvider.GetRomanSymbols().ToList();

			Assert.AreEqual(numerals.Count, 13);
		}

		[Test]
		[TestCase(0, 1000, "M")]
		[TestCase(1, 900, "CM")]
		[TestCase(2, 500, "D")]
		[TestCase(3, 400, "CD")]
		[TestCase(4, 100, "C")]
		[TestCase(5, 90, "XC")]
		[TestCase(6, 50, "L")]
		[TestCase(7, 40, "XL")]
		[TestCase(8, 10, "X")]
		[TestCase(9, 9, "IX")]
		[TestCase(10, 5, "V")]
		[TestCase(11, 4, "IV")]
		[TestCase(12, 1, "I")]
		public void Should_provide_ordered_and_correct_known_values_for_roman_numerals(int index, int key, string value)
		{
			var numerals = RomanSymbolsProvider.GetRomanSymbols().ToList();

			Assert.That(numerals[index].Key.Equals(key));
			Assert.That(numerals[index].Value.Equals(value));
		}
	}
}
