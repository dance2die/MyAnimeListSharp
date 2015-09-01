using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public abstract class SearchRequestParameters : RequestParameters
	{
		public abstract override string BaseUri { get; set; }
		public override string HttpMethod { get; set; } = "GET";

		public string SearchTerm
		{
			get { return QueryProperties["q"]; }
			set { QueryProperties["q"] = value; }
		}

		protected SearchRequestParameters(ICredentialContext credential, string searchTerm) 
			: base(credential)
		{
			SearchTerm = searchTerm;
		}
	}
}