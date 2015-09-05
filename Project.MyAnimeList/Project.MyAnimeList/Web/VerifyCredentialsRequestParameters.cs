using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Web
{
	public class VerifyCredentialsRequestParameters : RequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/account/verify_credentials.xml";
		public override string HttpMethod { get; set; } = "GET";

		public VerifyCredentialsRequestParameters(ICredentialContext credential) 
			: base(credential)
		{
			Credential = credential;
		}
	}
}