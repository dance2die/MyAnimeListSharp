using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class AccountMethodsAsync : MyAnimeListMethodsAsync
	{
		public AccountMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public Task<string> VerifyCredentialsAsync()
		{
			return GetResponseTextAsync(new VerifyCredentialsRequestParameters(CredentialContext));
		}
	}
}