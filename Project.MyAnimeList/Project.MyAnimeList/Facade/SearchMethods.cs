using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Facade
{
	public class SearchMethods : MyAnimeListMethods
	{
		public SearchMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		public string SearchAnime(string searchTerm)
		{
			return GetResponseText(new AnimeSearchRequestParameters(CredentialContext, searchTerm));
		}

		public AnimeSearchResponse SearchAnimeDeserialized(string searchTerm)
		{
			var responseString = SearchAnime(searchTerm);
			return new AnimeSearchResponseDeserializer().Deserialize(responseString);
		}

		public string SearchManga(string searchTerm)
		{
			return GetResponseText(new MangaSearchRequestParameters(CredentialContext, searchTerm));
		}

		public MangaSearchResponse SearchMangaDeserialized(string searchTerm)
		{
			var responseString = SearchManga(searchTerm);
			return new MangaSearchResponseDeserializer().Deserialize(responseString);
		}
	}
}