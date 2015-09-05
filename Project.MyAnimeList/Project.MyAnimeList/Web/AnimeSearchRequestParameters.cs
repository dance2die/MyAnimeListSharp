using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Web
{
	public class AnimeSearchRequestParameters : SearchRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/anime/search.xml";

		public AnimeSearchRequestParameters(ICredentialContext credentialContext, string searchTerm)
			: base(credentialContext, searchTerm)
		{
		}
	}
}