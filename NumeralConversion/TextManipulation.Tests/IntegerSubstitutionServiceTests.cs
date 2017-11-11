using NSubstitute;
using NumeralConversion;
using NUnit.Framework;

namespace TextManipulation.Tests
{
	[TestFixture]
	internal class IntegerSubstitutionServiceTests
	{
		private IntegerSubstitutionService service;
		private INumeralConverter<int, string> converter;
		
		[SetUp]
		public void SetUp()
		{
			converter = Substitute.For<INumeralConverter<int, string>>();
			converter.Convert(Arg.Any<int>()).Returns("convertedNumeral");
			service = new IntegerSubstitutionService(SearchPatterns.IntegerFrom1To3999Pattern, converter);
		}

		[Test]
		[TestCase("Ut enim quis nostrum 1904 qui.", "Ut enim quis nostrum convertedNumeral qui.", 1)]
		[TestCase("Consectetur 5 adipiscing elit 9.", "Consectetur convertedNumeral adipiscing elit convertedNumeral.", 2)]
		[TestCase("Lorem ipsum 2 dolor sit amet.", "Lorem ipsum convertedNumeral dolor sit amet.", 1)]
		[TestCase("123 456 7890", "convertedNumeral convertedNumeral 7890", 2)]
		[TestCase("AAA123 BBB456 DDD7890", "AAA123 BBB456 DDD7890", 0)]
		[TestCase("Should substitute this 5 but not this5.", "Should substitute this convertedNumeral but not this5.", 1)]
		[TestCase("Substitute this 1234 multiple 1234 times 1234.", "Substitute this convertedNumeral multiple convertedNumeral times convertedNumeral.", 3)]
		public void Should_substitute_arabic_numerals(string inputText, string expectedOutputText, int expectedNumberOfSubstitutions)
		{
			var result = service.Substitute(inputText);

			Assert.That(result.NumberOfSubstitutions.Equals(expectedNumberOfSubstitutions));
			Assert.That(result.ResultedText.Equals(expectedOutputText));
		}
	}
}
