using NumeralConversion;
using NUnit.Framework;
using TextManipulation;

namespace IntegrationTests
{
	[TestFixture]
	internal class ArabicToRomanConversionTests
	{
		private INumeralConverter<int, string> arabicToRomanConverter;
		private ISubstitutionService substitutionService;

		[SetUp]
		public void SetUp()
		{
			arabicToRomanConverter = new ArabicToRomanConverter();
			substitutionService = new IntegerSubstitutionService(SearchPatterns.IntegerPattern, arabicToRomanConverter);
		}

		[Test]
		[TestCase("Ut enim quis nostrum 1904 qui.", "Ut enim quis nostrum M CM IV qui.", 1)]
		[TestCase("Consectetur 5 adipiscing elit 9.", "Consectetur V adipiscing elit IX.", 2)]
		[TestCase("Lorem ipsum 2 dolor sit amet.", "Lorem ipsum II dolor sit amet.", 1)]
		public void Should_substitute_arabic_with_roman_numerals(string inputText, string expectedOutputText, int expectedNumberOfSubstitutions)
		{
			var result = substitutionService.Substitute(inputText);

			Assert.That(result.NumberOfSubstitutions.Equals(expectedNumberOfSubstitutions));
			Assert.That(result.ResultedText.Equals(expectedOutputText));
		}
	}
}