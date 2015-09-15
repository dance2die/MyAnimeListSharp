using MyAnimeListSharp.Core;
using MyAnimeListSharp.Util;

namespace Project.MyAnimeList.Test.Fixture
{
	public class AnimeSearchResponseDeserializerFixture
	{
		public SearchResponseDeserializer<AnimeSearchResponse> Deserializer { get; set; } 
			= new SearchResponseDeserializer<AnimeSearchResponse>();
	}
}