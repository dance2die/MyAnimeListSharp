using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
    public class VerifyCredentialsRequestParameters : RequestParameters
    {
        public VerifyCredentialsRequestParameters(ICredentialContext credential)
            : base(credential)
        {
            Credential = credential;
        }

        public override string RelativeUri { get; set; } = "api/account/verify_credentials.xml";
        public override string HttpMethod { get; set; } = "GET";
    }
}