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
			substitutionService = new IntegerSubstitutionService(SearchPatterns.IntegerFrom1To3999Pattern, arabicToRomanConverter);
		}

		[Test]
		[TestCase("Ut enim quis nostrum 1904 qui.", "Ut enim quis nostrum M CM IV qui.", 1)]
		[TestCase("Consectetur 5 adipiscing elit 9.", "Consectetur V adipiscing elit IX.", 2)]
		[TestCase("Lorem ipsum 2 dolor sit amet.", "Lorem ipsum II dolor sit amet.", 1)]
		[TestCase("12345 abc1 67!", "12345 abc1 LX VII!", 1)]
		[TestCase("Should replace 2080 with roman numeral 2080.", "Should replace MM LXXX with roman numeral MM LXXX.", 2)]
		[TestCase("...309...309309!", "...CCC IX...309309!", 1)]
		[TestCase("6/11/63/2222", "VI/X I/LX III/MM CC XX II", 4)]
		public void Should_substitute_integers_between_1_and_3999_with_roman_numerals(string inputText, string expectedOutputText, int expectedNumberOfSubstitutions)
		{
			var result = substitutionService.Substitute(inputText);

			Assert.That(result.NumberOfSubstitutions.Equals(expectedNumberOfSubstitutions));
			Assert.That(result.ResultedText.Equals(expectedOutputText));
		}
	}
}