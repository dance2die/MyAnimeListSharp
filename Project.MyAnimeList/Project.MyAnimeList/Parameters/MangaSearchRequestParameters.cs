using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
    public class MangaSearchRequestParameters : SearchRequestParameters
    {
        public MangaSearchRequestParameters(ICredentialContext credentialContext, string searchTerm)
            : base(credentialContext, searchTerm)
        {
        }

        public override string RelativeUri { get; set; } = "api/manga/search.xml";
    }
}