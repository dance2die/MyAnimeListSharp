namespace MyAnimeListSharp.Formatters
{
	public interface IFormatter<in T>
	{
		string Format(T value);
	}
}