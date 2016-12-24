using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public class AnimeSearchRequestParameters : SearchRequestParameters
	{
		public AnimeSearchRequestParameters(ICredentialContext credentialContext, string searchTerm)
			: base(credentialContext, searchTerm)
		{
		}

		public override string RelativeUri { get; set; } = "api/anime/search.xml";
	}
}