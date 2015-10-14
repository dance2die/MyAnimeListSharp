using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class MangaListMethodsAsync : MyAnimeListMethods
	{
		public MangaListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public async Task<string> AddMangaAsync(int? id, string data)
		{
			return await GetResponseTextAsync(new AddMangaRequestParameters(CredentialContext, id, data));
		}

		public async Task<string> AddMangaAsync(int? id, MangaValues mangaValues)
		{
			var data = GetDataStringFromMyAnimeListValues(mangaValues);
			return await AddMangaAsync(id, data);
		}

		public async Task<string> UpdateMangaAsync(int? id, string data)
		{
			return await GetResponseTextAsync(new UpdateMangaRequestParameters(CredentialContext, id, data));
		}

		public async Task<string> UpdateMangaAsync(int? id, MangaValues mangaValues)
		{
			var data = GetDataStringFromMyAnimeListValues(mangaValues);
			return await UpdateMangaAsync(id, data);
		}

		public async Task<string> DeleteMangaAsync(int? id)
		{
			return await GetResponseTextAsync(new DeleteMangaRequestParameters(CredentialContext, id));
		}
	}
}