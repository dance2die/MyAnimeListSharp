using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public class DeleteAnimeRequestParameters : CrudRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/animelist/delete";

		public DeleteAnimeRequestParameters(ICredentialContext credential, int? id, string data = "") 
			: base(credential, id, data)
		{
		}
	}
}