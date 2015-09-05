using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Web
{
	public class UpdateAnimeRequestParameters : CrudRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/animelist/update";

		public UpdateAnimeRequestParameters(ICredentialContext credentialContext, int? id, string data)
			: base(credentialContext, id, data)
		{
		}
	}
}