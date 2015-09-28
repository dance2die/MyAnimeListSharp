using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Facade
{
	/// <summary>
	/// Represents a "Search Methods" section in MyAnimeList.net specification.
	/// <see cref="http://myanimelist.net/modules.php?go=api"/>
	/// </summary>
	public class SearchMethods : MyAnimeListMethods
	{
		public SearchMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		/// <summary>
		/// Search anime by the given search term.
		/// </summary>
		/// <param name="searchTerm">Anime to search</param>
		/// <returns>XML response in string format</returns>
		public string SearchAnime(string searchTerm)
		{
			return GetResponseText(new AnimeSearchRequestParameters(CredentialContext, searchTerm));
		}

		/// <summary>
		/// Search anime by the given search term.
		/// </summary>
		/// <param name="searchTerm">Anime to search</param>
		/// <returns>XML response deserialized into an object</returns>
		public AnimeSearchResponse SearchAnimeDeserialized(string searchTerm)
		{
			var responseString = SearchAnime(searchTerm);
			return new SearchResponseDeserializer<AnimeSearchResponse>().Deserialize(responseString);
		}

		/// <summary>
		/// Search manga by the given search term.
		/// </summary>
		/// <param name="searchTerm">Manga to search</param>
		/// <returns>XML response in string format</returns>
		public string SearchManga(string searchTerm)
		{
			return GetResponseText(new MangaSearchRequestParameters(CredentialContext, searchTerm));
		}

		/// <summary>
		/// Search manga by the given search term.
		/// </summary>
		/// <param name="searchTerm">Manga to search</param>
		/// <returns>XML response deserialized into an object</returns>
		public MangaSearchResponse SearchMangaDeserialized(string searchTerm)
		{
			var responseString = SearchManga(searchTerm);
			return new SearchResponseDeserializer<MangaSearchResponse>().Deserialize(responseString);
		}
	}
}