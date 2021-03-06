﻿using System;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
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
			service = new IntegerSubstitutionService(IntegerMatcher.From1To3999, converter);
		}

		[Test]
		[TestCase("Ut enim quis nostrum 1904 qui.", "Ut enim quis nostrum convertedNumeral qui.", 1)]
		[TestCase("Consectetur 5 adipiscing elit 9.", "Consectetur convertedNumeral adipiscing elit convertedNumeral.", 2)]
		[TestCase("Lorem ipsum 2 dolor sit amet.", "Lorem ipsum convertedNumeral dolor sit amet.", 1)]
		[TestCase("123 456 7890", "convertedNumeral convertedNumeral 7890", 2)]
		[TestCase("AAA123 BBB456 DDD7890", "AAA123 BBB456 DDD7890", 0)]
		[TestCase("Should substitute this 5 but not this5.", "Should substitute this convertedNumeral but not this5.", 1)]
		[TestCase("Substitute this 1234 multiple 1234 times 1234.", "Substitute this convertedNumeral multiple convertedNumeral times convertedNumeral.", 3)]
		public void Should_substitute_arabic_integers_between_1_and_3999(string inputText, string expectedOutputText, int expectedNumberOfSubstitutions)
		{
			var result = service.Substitute(inputText);

			Assert.That(result.NumberOfSubstitutions.Equals(expectedNumberOfSubstitutions));
			Assert.That(result.ResultedText.Equals(expectedOutputText));
		}

		[Test]
		public void Should_throw_exception_when_converter_throws()
		{
			converter.Convert(Arg.Any<int>())
				.Throws(new ArgumentException(
					"The number to be converted to a roman numeral is out of the accepted range! \r\nParameter name: input"));

			var ex = Assert.Throws<Exception>(() => service.Substitute("Some string to 123 search."));

			Assert.That(ex.InnerException.Message.Equals("The number to be converted to a roman numeral is out of the accepted range! \r\nParameter name: input"));
			Assert.That(ex.Message.Equals(@"There was an error during the substitution process.
			Please make sure that the pattern is matching integers and that the matched values are compatible with the converter.
			See inner exception for deatils"));
		}
	}
}
