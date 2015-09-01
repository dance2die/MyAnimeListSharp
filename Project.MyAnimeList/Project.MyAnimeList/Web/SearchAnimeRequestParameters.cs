using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public class SearchAnimeRequestParameters : RequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/anime/search.xml";
		public override string HttpMethod { get; set; } = "GET";

		public string SearchTerm
		{
			get { return QueryProperties["q"]; }
			set { QueryProperties["q"] = value; }
		}

		public SearchAnimeRequestParameters(ICredentialContext credentialContext, string searchTerm)
			: base(credentialContext)
		{
			SearchTerm = searchTerm;
		}
	}
}