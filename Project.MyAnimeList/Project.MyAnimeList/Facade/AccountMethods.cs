using Project.MyAnimeList.Auth;
using Project.MyAnimeList.Web;

namespace Project.MyAnimeList.Facade
{
	public class AccountMethods : MyAnimeListMethods
	{
		public AccountMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		public string VerifyCredentials()
		{
			return GetResponseText(new VerifyCredentialsRequestParameters(CredentialContext));
		}
	}
}