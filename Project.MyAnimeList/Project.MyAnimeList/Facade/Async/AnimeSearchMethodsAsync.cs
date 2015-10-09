using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Facade.Async
{
	public class AnimeSearchMethodsAsync : MyAnimeListMethodsAsync
	{
		public AnimeSearchMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}

		public async Task<string> SearchAsync(string searchTerm)
		{
			return await GetResponseTextAsync(new AnimeSearchRequestParameters(CredentialContext, searchTerm));
		}

		public async Task<AnimeSearchResponse> SearchDeserializedAsync(string searchTerm)
		{
			// ConfigureAwait(false) => There is no need to overload the workload by marshalling the current context.
			var response = await SearchAsync(searchTerm).ConfigureAwait(false);
			if (string.IsNullOrWhiteSpace(response))
				return new AnimeSearchResponse();

			return await Task.Run(() => new SearchResponseDeserializer<AnimeSearchResponse>().Deserialize(response));
		}
	}
}