using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class MangaListMethodsAsync : MyAnimeListMethodsAsync
	{
		public MangaListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public async Task<string> AddMangaAsync(int? id, string data)
		{
			return await GetResponseTextAsync(new AddMangaRequestParameters(CredentialContext, id, data));
		}
	}
}