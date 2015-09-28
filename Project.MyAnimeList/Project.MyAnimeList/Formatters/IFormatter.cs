namespace MyAnimeListSharp.Formatters
{
	/// <summary>
	/// Convert any given object of type T to a string
	/// </summary>
	/// <typeparam name="T">Type of an object to convert to string</typeparam>
	public interface IFormatter<in T>
	{
		string Format(T value);
	}
}