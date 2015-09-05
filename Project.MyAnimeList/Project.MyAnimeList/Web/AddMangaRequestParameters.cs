using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Web
{
	public class AddMangaRequestParameters : CrudRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/mangalist/add";

		public AddMangaRequestParameters(ICredentialContext credential, int? id, string data) 
			: base(credential, id, data)
		{
		}
	}
}