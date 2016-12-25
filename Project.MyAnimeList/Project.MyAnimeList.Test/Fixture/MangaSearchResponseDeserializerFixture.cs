using MyAnimeListSharp.Core;
using MyAnimeListSharp.Util;

namespace Project.MyAnimeList.Test.Fixture
{
    public class MangaSearchResponseDeserializerFixture
    {
        public SearchResponseDeserializer<MangaSearchResponse> Deserializer { get; set; }
        = new SearchResponseDeserializer<MangaSearchResponse>();
    }
}