namespace TextManipulation
{
	public class IntegerMatcher
	{
		private IntegerMatcher(string value) { Value = value; }

		public string Value { get; }

		public static IntegerMatcher From1To3999 => new IntegerMatcher(@"(?<!-)\b([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-3][0-9][0-9][0-9])\b");
	}
}
