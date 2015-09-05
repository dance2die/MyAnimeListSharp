using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Web;

namespace MyAnimeListSharp.Facade
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