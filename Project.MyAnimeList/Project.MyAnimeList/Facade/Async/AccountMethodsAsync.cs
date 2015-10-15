using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class AccountMethodsAsync : MyAnimeListMethods
	{
		public AccountMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public async Task<string> VerifyCredentialsAsync()
		{
			return await GetResponseTextAsync(new VerifyCredentialsRequestParameters(CredentialContext));
		}
	}
}