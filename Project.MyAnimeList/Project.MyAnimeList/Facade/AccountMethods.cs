using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade
{
	/// <summary>
	/// Represents a "Account Methods" section in MyAnimeList.net specification.
	/// <see cref="http://myanimelist.net/modules.php?go=api"/>
	/// </summary>
	public class AccountMethods : MyAnimeListMethods
	{
		public AccountMethods(ICredentialContext credentialContext)
			: base(credentialContext)
		{
		}

		/// <summary>
		/// Check if the credential is valid or not
		/// </summary>
		/// <returns>Response from the server in raw string</returns>
		public string VerifyCredentials()
		{
			return GetResponseText(new VerifyCredentialsRequestParameters(CredentialContext));
		}
	}
}