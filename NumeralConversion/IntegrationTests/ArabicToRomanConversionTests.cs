using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		[Test]
		[TestCase(" 75 ", " LXX V ", 1)]
		[TestCase(" 75 2 ", " LXX V II ", 2)]
		[TestCase(" 75ab ", " 75ab ", 0)]
		public void Should_substitute_integers_with_roman_numerals_in_huge_string(string arabicNumeral, string romanNumeral, int substitutions)
		{
			var hugeInputText = HugeStringProvider(arabicNumeral);
			var hugeOutputText = HugeStringProvider(romanNumeral);

			var result = substitutionService.Substitute(hugeInputText);
			Assert.That(result.NumberOfSubstitutions.Equals(substitutions));
			Assert.That(result.ResultedText.Equals(hugeOutputText));
		}

		[Test]
		public void Should_work_with_parallell_calls_to_the_substitution_service()
		{
			var hugeInput1 = HugeStringProvider(" 6 7 8 ");
			var hugeInput2 = HugeStringProvider(" 60 70 80 ");

			var hugeOutput1 = HugeStringProvider(" VI VII VIII ");
			var hugeOutput2 = HugeStringProvider(" LX LXX LXXX ");

			var result1 = Task.Run(() => substitutionService.Substitute(hugeInput1));
			var result2 = Task.Run(() => substitutionService.Substitute(hugeInput2));

			Task.WaitAll(result1, result2);

			Assert.That(result1.Result.NumberOfSubstitutions.Equals(3));
			Assert.That(result1.Result.ResultedText.Equals(hugeOutput1));
			Assert.That(result2.Result.NumberOfSubstitutions.Equals(3));
			Assert.That(result2.Result.ResultedText.Equals(hugeOutput2));
		}

		private static string HugeStringProvider(string middleValue)
		{
			var hugeTextBuilder = new StringBuilder();
			hugeTextBuilder.Append(string.Join("", Enumerable.Repeat("p", 100000000)));
			hugeTextBuilder.Append(middleValue);
			hugeTextBuilder.Append(string.Join("", Enumerable.Repeat("q", 100000000)));

			return hugeTextBuilder.ToString();
		}
	}
}