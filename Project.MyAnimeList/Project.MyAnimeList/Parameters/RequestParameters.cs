using System.Collections.Generic;
using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public abstract class RequestParameters
	{
		protected RequestParameters(ICredentialContext credential, int? id = null)
		{
			Credential = credential;
			Id = id;
		}

		public int? Id { get; set; }
		public ICredentialContext Credential { get; set; }
		public virtual Dictionary<string, string> QueryProperties { get; } = new Dictionary<string, string>();
		public virtual Dictionary<string, string> PostBodyProperties { get; } = new Dictionary<string, string>();

		public abstract string BaseUri { get; set; }
		public abstract string HttpMethod { get; set; }
	}
}