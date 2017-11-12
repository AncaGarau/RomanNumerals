﻿using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace TextManipulation.Tests
{
	[TestFixture]
	internal class SearchPatternsTests
	{
		[Test]
		public void Should_detect_integers_between_1_and_3999_correctly()
		{
			foreach (var i in Enumerable.Range(1, 3999))
				Assert.That(Regex.IsMatch(i.ToString(), SearchPatterns.IntegerFrom1To3999Pattern));
		}

		[Test]
		[TestCase(0)]
		[TestCase(4000)]
		[TestCase(18907)]
		[TestCase(123456789)]
		[TestCase(5670)]
		[TestCase(int.MaxValue)]
		public void Should_not_match_zero_or_integers_bigger_than_3999(int value)
		{
			Assert.IsFalse(Regex.IsMatch(value.ToString(), SearchPatterns.IntegerFrom1To3999Pattern));
		}

		[Test]
		[TestCase("This text should 12233 contain 1234 matches 67.", 2)]
		[TestCase("1 This text should contain 1234 matches ,678.", 3)]
		[TestCase("?1 This 3999 text -123 should contain 1234 matches ,678. 7", 6)]
		[TestCase("/899999/67 Th1s 21 text -4.5 should c0ntain 90 matche5!!!", 5)]
		[TestCase("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee 4-70 tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt", 2)]
		[TestCase("386.111.09", 2)]
		public void Should_detect_integers_between_1_and_3999_within_complex_text(string text, int numberOfMatches)
		{
			var matches = Regex.Matches(text, SearchPatterns.IntegerFrom1To3999Pattern);
			Assert.That(matches.Count.Equals(numberOfMatches));
		}
	}
}