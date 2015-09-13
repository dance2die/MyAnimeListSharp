using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public class DeleteAnimeRequestParameters : CrudRequestParameters
	{
		public DeleteAnimeRequestParameters(ICredentialContext credential, int? id, string data = "")
			: base(credential, id, data)
		{
		}

		public override string BaseUri { get; set; } = "http://myanimelist.net/api/animelist/delete";
	}
}