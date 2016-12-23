using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public class AddAnimeRequestParameters : CrudRequestParameters
	{
		public AddAnimeRequestParameters(ICredentialContext credentialContext, int? id, string data)
			: base(credentialContext, id, data)
		{
		}

		public override string RelativeUri { get; set; } = "animelist/add";
	}
}