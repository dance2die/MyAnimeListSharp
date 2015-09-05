using System.Collections.Generic;
using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Web
{
	public abstract class RequestParameters
	{
		public int? Id { get; set; }
		public ICredentialContext Credential { get; set; }
		public virtual Dictionary<string, string> QueryProperties { get; } = new Dictionary<string, string>();
		public virtual Dictionary<string, string> PostBodyProperties { get; } = new Dictionary<string, string>();

		protected RequestParameters(ICredentialContext credential, int? id = null)
		{
			Credential = credential;
			Id = id;
		}

		public abstract string BaseUri { get; set; }
		public abstract string HttpMethod { get; set; }
	}
}