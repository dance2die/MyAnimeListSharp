using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Web;

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

		public string UpdateAnime(int? id, string data)
		{
			return GetResponseText(new UpdateAnimeRequestParameters(CredentialContext, id, data));
		}

		public string DeleteAnime(int id)
		{
			return GetResponseText(new DeleteAnimeRequestParameters(CredentialContext, id));
		}
	}
}