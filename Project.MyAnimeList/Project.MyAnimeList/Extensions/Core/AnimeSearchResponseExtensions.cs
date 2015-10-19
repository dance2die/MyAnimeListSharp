using MyAnimeListSharp.Core;
using MyAnimeListSharp.Formatters;

namespace MyAnimeListSharp.Extensions.Core
{
	public static class AnimeSearchResponseExtensions
	{
		public static string ToJson(this AnimeSearchResponse response)
		{
			return new JsonFormatter<AnimeSearchResponse>().Format(response);
		}

		public static string ToXml(this AnimeSearchResponse response)
		{
			return new GenericXmlFormatter<AnimeSearchResponse>().Format(response);
		}
	}
}
