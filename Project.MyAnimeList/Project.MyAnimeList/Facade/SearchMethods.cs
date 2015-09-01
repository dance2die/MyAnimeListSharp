using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Facade
{
	public class SearchMethods : MyAnimeListMethods
	{
		public SearchMethods(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}
	}
}