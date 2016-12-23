using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public class UpdateAnimeRequestParameters : CrudRequestParameters
	{
		public UpdateAnimeRequestParameters(ICredentialContext credentialContext, int? id, string data)
			: base(credentialContext, id, data)
		{
		}

		public override string RelativeUri { get; set; } = "animelist/update";
	}
}