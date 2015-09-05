using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Web
{
	public class DeleteMangaRequestParameters : CrudRequestParameters
	{
		public override string BaseUri { get; set; } = "http://myanimelist.net/api/mangalist/delete";

		/// <remarks>
		/// Data is not required for deleting a manga entry
		/// </remarks>
		public DeleteMangaRequestParameters(ICredentialContext credential, int? id) 
			: base(credential, id, null)
		{
		}
	}
}