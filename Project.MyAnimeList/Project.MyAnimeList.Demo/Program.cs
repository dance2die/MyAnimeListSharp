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
			//HttpWebRequest request = CreateCredentialWebRequest(credential);
			//string responseFromServer = GetResponseText(request);
			RequestParameters requestParameters = new VerifyCredentialsRequestParameters(credential);
			string responseFromServer  = new AccountMethods(requestParameters).VerifyCredentials();

			Console.WriteLine(responseFromServer);
		}

		private static HttpWebRequest CreateCredentialWebRequest(ICredentialContext credential)
		{
			RequestParameters requestParameters = new VerifyCredentialsRequestParameters(credential);
			return WebRequestBuilder.BuildWebRequest(requestParameters);
		}
	}

	public class AccountMethods : MyAnimeListMethods
	{
		public AccountMethods(RequestParameters requestParameters)
		{
			RequestParameters = requestParameters;
		}

		public string VerifyCredentials()
		{
			return GetResponseText(WebRequestBuilder.BuildWebRequest(RequestParameters));
		}
	}

	public abstract class MyAnimeListMethods
	{
		public RequestParameters RequestParameters { get; set; }

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
