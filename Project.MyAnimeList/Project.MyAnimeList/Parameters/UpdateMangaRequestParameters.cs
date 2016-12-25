using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
    public class UpdateMangaRequestParameters : CrudRequestParameters
    {
        public UpdateMangaRequestParameters(ICredentialContext credential, int? id, string data)
            : base(credential, id, data)
        {
        }

        public override string RelativeUri { get; set; } = "api/mangalist/update";
    }
}