namespace Project.MyAnimeList
{
	public abstract class RequestParameters
	{
		public ICredentialContext Credential { get; set; }

		protected RequestParameters(ICredentialContext credential)
		{
			Credential = credential;
		}

		public abstract string RequestUri { get; set; }
		public abstract string HttpMethod { get; set; }
	}
}