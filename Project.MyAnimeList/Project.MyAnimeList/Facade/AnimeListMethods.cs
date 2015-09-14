using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade
{
	public class AnimeListMethods : MyAnimeListMethods
	{
		public AnimeListMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		public string AddAnime(int? id, string data)
		{
			return GetResponseText(new AddAnimeRequestParameters(CredentialContext, id, data));
		}

		public string AddAnime(int? id, AnimeValues animeValues)
		{
			string data = GetDataStringFromMyAnimeListValues(animeValues);
			return AddAnime(id, data);
		}

		public string UpdateAnime(int? id, string data)
		{
			return GetResponseText(new UpdateAnimeRequestParameters(CredentialContext, id, data));
		}

		public string UpdateAnime(int iD, AnimeValues animeValues)
		{
			string data = GetDataStringFromMyAnimeListValues(animeValues);
			return UpdateAnime(iD, data);
		}

		public string DeleteAnime(int id)
		{
			return GetResponseText(new DeleteAnimeRequestParameters(CredentialContext, id));
		}
	}
}