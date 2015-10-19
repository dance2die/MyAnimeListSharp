using MyAnimeListSharp.Core;
using Newtonsoft.Json;

namespace MyAnimeListSharp.Formatters
{
	public class MangaSearchResponseJsonFormatter : IFormatter<MangaSearchResponse>
	{
		public string Format(MangaSearchResponse value)
		{
			return JsonConvert.SerializeObject(value);
		}
	}
}