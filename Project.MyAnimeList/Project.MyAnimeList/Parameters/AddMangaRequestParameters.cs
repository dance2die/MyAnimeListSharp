using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public class AddMangaRequestParameters : CrudRequestParameters
	{
		public AddMangaRequestParameters(ICredentialContext credential, int? id, string data)
			: base(credential, id, data)
		{
		}

		public override string RelativeUri { get; set; } = "api/mangalist/add";
	}
}