using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public class DeleteMangaRequestParameters : CrudRequestParameters
	{
		/// <remarks>
		///     Data is not required for deleting a manga entry
		/// </remarks>
		public DeleteMangaRequestParameters(ICredentialContext credential, int? id)
			: base(credential, id, null)
		{
		}

		public override string RelativeUri { get; set; } = "mangalist/delete";
	}
}