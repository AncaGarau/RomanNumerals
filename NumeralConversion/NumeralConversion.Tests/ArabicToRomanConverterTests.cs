using NUnit.Framework;

namespace NumeralConversion.Tests
{
	[TestFixture]
	internal class ArabicToRomanConverterTests
	{
		private INumeralConverter<int, string> converter = new ArabicToRomanConverter();

		[Test]
		[TestCase(1, "I")]
		[TestCase(2, "II")]
		[TestCase(3, "III")]
		[TestCase(4, "IV")]
		[TestCase(5, "V")]
		[TestCase(8, "VIII")]
		[TestCase(9, "IX")]
		[TestCase(10, "X")]
		[TestCase(19, "XIX")]
		[TestCase(20, "XX")]
		[TestCase(35, "XXXV")]
		[TestCase(40, "XL")]
		[TestCase(48, "XLVIII")]
		[TestCase(50, "L")]
		[TestCase(77, "LXXVII")]
		[TestCase(90, "XC")]
		[TestCase(100, "C")]
		[TestCase(265, "CCLXV")]
		[TestCase(489, "CDLXXXIX")]
		[TestCase(500, "D")]
		[TestCase(861, "DCCCLXI")]
		[TestCase(900, "CM")]
		[TestCase(936, "CMXXXVI")]
		[TestCase(1000, "M")]
		[TestCase(1992, "MCMXCII")]
		[TestCase(2000, "MM")]
		[TestCase(2017, "MMXVII")]
		[TestCase(3999, "MMMCMXCIX")]
		public void Should_convert_arabic_to_roman_numerals_correctly(int input, string expectedOutput)
		{
			var actualOutput = converter.Convert(input);

			Assert.AreEqual(actualOutput, expectedOutput);
		}
	}
}
