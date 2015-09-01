using System.Collections.Generic;
using Project.MyAnimeList.Auth;
using Project.MyAnimeList.Web;

namespace Project.MyAnimeList.Facade
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

		public string SearchManga(string searchTerm)
		{
			return GetResponseText(new MangaSearchRequestParameters(CredentialContext, searchTerm));
		}
	}
}