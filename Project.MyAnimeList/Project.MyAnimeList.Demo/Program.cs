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
		}

		private static void TestCredentials(ICredentialContext credential)
		{
			HttpWebRequest request = CreateCredentialWebRequest(credential);
			using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
			using (Stream responseStream = response.GetResponseStream())
			using (StreamReader reader = new StreamReader(responseStream))
			{
				//Read the content.
				string responseFromServer = reader.ReadToEnd();
			}
		}

		private static HttpWebRequest CreateCredentialWebRequest(ICredentialContext credential)
		{
			RequestParameters requestParameters = new VerifyCredentialsRequestParameters(credential);
			return CreateWebRequest(requestParameters);
		}

		private static HttpWebRequest CreateWebRequest(RequestParameters requestParameters)
		{
			HttpWebRequest result = WebRequest.Create(requestParameters.RequestUri) as HttpWebRequest;
			if (result == null)
				throw new InvalidOperationException("Could not create web request");

			result.ContentType = "application/x-www-form-urlencoded";

			// credit
			// https://github.com/DeadlyEmbrace/MyAnimeListAPI/blob/master/MyAnimeListAPI/MyAnimeListAPI/Credentials.cs
			result.Method = requestParameters.HttpMethod;
			result.UseDefaultCredentials = false;
			result.Credentials = new NetworkCredential(
				requestParameters.Credential.UserName, requestParameters.Credential.Password);
			// credit
			// https://github.com/LHCGreg/mal-api/blob/f6c82c95d139807a1d6259200ec7622384328bc3/MalApi/MyAnimeListApi.cs
			result.AutomaticDecompression = DecompressionMethods.GZip;

			return result;
		}
	}

	public class VerifyCredentialsRequestParameters : RequestParameters
	{
		public override string RequestUri { get; set; } = "http://myanimelist.net/api/account/verify_credentials.xml";
		public override string HttpMethod { get; set; } = "GET";

		public VerifyCredentialsRequestParameters(ICredentialContext credential) 
			: base(credential)
		{
			Credential = credential;
		}
	}

	public abstract class RequestParameters
	{
		public ICredentialContext Credential { get; set; }

		protected RequestParameters(ICredentialContext credential)
		{
			Credential = credential;
		}

		public abstract string RequestUri { get; set; }
		public abstract string HttpMethod { get; set; }
	}
}
