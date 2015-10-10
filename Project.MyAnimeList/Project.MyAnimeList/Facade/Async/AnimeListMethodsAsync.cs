using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Facade.Async
{
	public class AnimeListMethodsAsync : MyAnimeListMethodsAsync
	{
		public AnimeListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public async Task<string> AddAnimeAsync(int id, string data)
		{
			return await GetResponseTextAsync(new AddAnimeRequestParameters(CredentialContext, id, data));
		}

		public async Task<string> AddAnimeAsync(int id, AnimeValues animeValues)
		{
			var data = GetDataStringFromMyAnimeListValues(animeValues);
			return await AddAnimeAsync(id, data);
		}
	}
}