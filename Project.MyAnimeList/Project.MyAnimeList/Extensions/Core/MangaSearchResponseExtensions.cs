using MyAnimeListSharp.Core;
using MyAnimeListSharp.Formatters;

namespace MyAnimeListSharp.Extensions.Core
{
    public static class MangaSearchResponseExtensions
    {
        public static string ToJson(this MangaSearchResponse response)
        {
            return new JsonFormatter<MangaSearchResponse>().Format(response);
        }

        public static string ToXml(this MangaSearchResponse response)
        {
            return new GenericXmlFormatter<MangaSearchResponse>().Format(response);
        }
    }
}