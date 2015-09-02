using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Web
{
	public abstract class CrudRequestParameters : RequestParameters
	{
		public int? Id { get; set; }
		public string Data { get; set; }
		public override string HttpMethod { get; set; } = "POST";

		protected CrudRequestParameters(ICredentialContext credential, int? id, string data) 
			: base(credential)
		{
			Id = id;
			Data = data;
		}
	}
}