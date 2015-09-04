using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public class UpdateMangaRequestParameters : CrudRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/mangalist/update";

		public UpdateMangaRequestParameters(ICredentialContext credential, int? id, string data) 
			: base(credential, id, data)
		{
		}
	}
}