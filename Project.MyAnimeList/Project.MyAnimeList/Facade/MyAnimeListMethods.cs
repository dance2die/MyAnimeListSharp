using System.IO;
using System.Net;
using Project.MyAnimeList.Auth;
using Project.MyAnimeList.Web;

namespace Project.MyAnimeList.Facade
{
	public abstract class MyAnimeListMethods
	{
		public ICredentialContext CredentialContext { get; set; }

		protected MyAnimeListMethods(ICredentialContext credentialContext)
		{
			CredentialContext = credentialContext;
		}

		/// <summary>
		/// Template method to return response text
		/// </summary>
		protected string GetResponseText(RequestParameters requestParameters)
		{
			var requestBuilder = new WebRequestBuilder(requestParameters);
			var request = requestBuilder.BuildWebRequest();

			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}