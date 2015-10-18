using MyAnimeListSharp.Core;
using Newtonsoft.Json;

namespace MyAnimeListSharp.Formatters
{
	public class AnimeSearchResponseJsonFormatter : IFormatter<AnimeSearchResponse>
	{
		public string Format(AnimeSearchResponse value)
		{
			return JsonConvert.SerializeObject(value);
		}
	}
}