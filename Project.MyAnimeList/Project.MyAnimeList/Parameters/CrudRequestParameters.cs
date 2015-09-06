using MyAnimeListSharp.Auth;

namespace MyAnimeListSharp.Parameters
{
	public abstract class CrudRequestParameters : RequestParameters
	{
		private const string DATA_BODY_NAME = "data";

		public string Data
		{
			get { return PostBodyProperties[DATA_BODY_NAME]; }
			set {  PostBodyProperties[DATA_BODY_NAME] = value; }
		}

		public override string HttpMethod { get; set; } = "POST";

		protected CrudRequestParameters(ICredentialContext credential, int? id, string data) 
			: base(credential, id)
		{
			Data = data;
		}
	}
}