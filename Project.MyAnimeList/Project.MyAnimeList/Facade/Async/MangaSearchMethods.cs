using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class MangaSearchMethods : MyAnimeListMethodsAsync
	{
		public MangaSearchMethods(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}


		public async Task<string> SearchAsync(string searchTerm)
		{
			return await GetResponseTextAsync(new MangaSearchRequestParameters(CredentialContext, searchTerm));
		}
	}
}