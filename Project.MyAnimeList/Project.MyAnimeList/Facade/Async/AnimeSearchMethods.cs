using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

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

		public async Task<AnimeSearchResponse> SearchDeserializedAsync(string searchTerm)
		{
			var response = await SearchAsync(searchTerm);
			if (string.IsNullOrWhiteSpace(response))
				return new AnimeSearchResponse();

			return await Task.Run(() => new SearchResponseDeserializer<AnimeSearchResponse>().Deserialize(response));
		}
	}
}