using System;
using System.IO;
using System.Net;

namespace Project.MyAnimeList.Demo
{
	public class Program
	{
		public static void Main(string[] args)
		{
			ICredentialContext credential = new CredentialContext();

			TestCredentials(credential);

			Console.WriteLine("Press ENTER to continue...");
			Console.ReadLine();
		}

		private static void TestCredentials(ICredentialContext credential)
		{
			HttpWebRequest request = CreateCredentialWebRequest(credential);
			string responseFromServer = GetResponseText(request);

			Console.WriteLine(responseFromServer);
		}

		private static string GetResponseText(HttpWebRequest request)
		{
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				//Read the content.
				string responseFromServer = reader.ReadToEnd();
				return responseFromServer;
			}
		}

		private static HttpWebRequest CreateCredentialWebRequest(ICredentialContext credential)
		{
			RequestParameters requestParameters = new VerifyCredentialsRequestParameters(credential);
			return WebRequestBuilder.BuildWebRequest(requestParameters);
		}
	}
}
