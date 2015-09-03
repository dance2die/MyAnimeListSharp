using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public class AddAnimeRequestParameters : CrudRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/animelist/add";

		public AddAnimeRequestParameters(ICredentialContext credentialContext, int? id, string data)
			: base(credentialContext, id, data)
		{
		}
	}
}