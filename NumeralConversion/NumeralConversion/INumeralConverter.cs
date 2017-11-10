namespace NumeralConversion
{
	public interface INumeralConverter<in TInput, out TOutput>
	{
		TOutput Convert(TInput input);
	}
}
