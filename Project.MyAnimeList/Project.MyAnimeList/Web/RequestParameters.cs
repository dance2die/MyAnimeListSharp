using System.Collections.Generic;
using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public abstract class RequestParameters
	{
		public ICredentialContext Credential { get; set; }
		public virtual Dictionary<string, string> QueryProperties { get; } = new Dictionary<string, string>();

		protected RequestParameters(ICredentialContext credential)
		{
			Credential = credential;
		}

		public abstract string BaseUri { get; set; }
		public abstract string HttpMethod { get; set; }
	}
}