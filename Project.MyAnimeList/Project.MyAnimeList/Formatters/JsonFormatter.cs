using Newtonsoft.Json;

namespace MyAnimeListSharp.Formatters
{
	public class JsonFormatter<T> : IFormatter<T>
	{
		public string Format(T value)
		{
			return JsonConvert.SerializeObject(value);
		}
	}
}