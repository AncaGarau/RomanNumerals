using System;
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
		[TestCase(19, "X IX")]
		[TestCase(20, "XX")]
		[TestCase(26, "XX VI")]
		[TestCase(35, "XXX V")]
		[TestCase(40, "XL")]
		[TestCase(48, "XL VIII")]
		[TestCase(50, "L")]
		[TestCase(77, "LXX VII")]
		[TestCase(90, "XC")]
		[TestCase(100, "C")]
		[TestCase(265, "CC LX V")]
		[TestCase(489, "CD LXXX IX")]
		[TestCase(500, "D")]
		[TestCase(699, "DC XC IX")]
		[TestCase(861, "DCCC LX I")]
		[TestCase(900, "CM")]
		[TestCase(936, "CM XXX VI")]
		[TestCase(1000, "M")]
		[TestCase(1992, "M CM XC II")]
		[TestCase(2000, "MM")]
		[TestCase(2017, "MM X VII")]
		[TestCase(3999, "MMM CM XC IX")]
		public void Should_convert_arabic_to_roman_numerals_correctly(int input, string expectedOutput)
		{
			var actualOutput = converter.Convert(input);

			Assert.AreEqual(actualOutput, expectedOutput);
		}

		[Test]
		[TestCase(0)]
		[TestCase(-50)]
		[TestCase(-8709)]
		[TestCase(4000)]
		[TestCase(4050)]
		[TestCase(43546732)]
		public void Should_throw_exception_with_specific_message_when_the_input_is_invalid(int input)
		{
			var ex = Assert.Throws<ArgumentException>(() => converter.Convert(input));

			Assert.AreEqual(ex.Message, "The number to be converted to a roman numeral is out of the accepted range! \r\nParameter name: input");
		}
	}
}
