namespace MyAnimeListSharp.Util
{
	public interface IFormatter<in T>
	{
		string Format(T value);
	}
}