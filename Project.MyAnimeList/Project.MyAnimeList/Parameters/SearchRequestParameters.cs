using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public abstract class SearchRequestParameters : RequestParameters
	{
		protected SearchRequestParameters(ICredentialContext credential, string searchTerm)
			: base(credential)
		{
			SearchTerm = searchTerm;
		}

		public abstract override string BaseUri { get; set; }
		public override string HttpMethod { get; set; } = "GET";

		public string SearchTerm
		{
			get { return QueryProperties["q"]; }
			set { QueryProperties["q"] = value; }
		}
	}
}