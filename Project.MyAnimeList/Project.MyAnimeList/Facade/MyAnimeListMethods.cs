using System.IO;
using System.Net;
using Project.MyAnimeList.Auth;

namespace Project.MyAnimeList.Facade
{
	public abstract class MyAnimeListMethods
	{
		public ICredentialContext CredentialContext { get; set; }

		protected MyAnimeListMethods(ICredentialContext credentialContext)
		{
			CredentialContext = credentialContext;
		}

		protected string GetResponseText(HttpWebRequest request)
		{
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}