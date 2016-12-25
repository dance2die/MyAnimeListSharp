using System.Threading.Tasks;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Facade.Async
{
    public class MangaSearchMethodsAsync : MyAnimeListMethods
    {
        public MangaSearchMethodsAsync(ICredentialContext credentialContext)
            : base(credentialContext)
        {
        }

        public async Task<string> SearchAsync(string searchTerm)
        {
            return await GetResponseTextAsync(new MangaSearchRequestParameters(CredentialContext, searchTerm));
        }

        public async Task<MangaSearchResponse> SearchDeserializedAsync(string searchTerm)
        {
            // ConfigureAwait(false) => There is no need to overload the workload by marshalling the current context.
            var response = await SearchAsync(searchTerm).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(response))
                return new MangaSearchResponse();

            return await Task.Run(() => new SearchResponseDeserializer<MangaSearchResponse>().Deserialize(response));
        }
    }
}