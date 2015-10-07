using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class AnimeSearchMethods : MyAnimeListMethodsAsync
	{
		public AnimeSearchMethods(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public async Task<string> SearchAsync(string searchTerm)
		{
			return await GetResponseTextTask(new AnimeSearchRequestParameters(CredentialContext, searchTerm));
		}
	}
}