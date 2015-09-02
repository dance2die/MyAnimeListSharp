using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public abstract class CrudRequestParameters : RequestParameters
	{
		public string Data { get; set; }
		public override string HttpMethod { get; set; } = "POST";

		protected CrudRequestParameters(ICredentialContext credential, int? id, string data) 
			: base(credential, id)
		{
			Data = data;
		}
	}
}