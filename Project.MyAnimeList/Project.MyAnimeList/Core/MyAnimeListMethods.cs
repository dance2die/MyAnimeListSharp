using System.IO;
using System.Net;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Core
{
	public abstract class MyAnimeListMethods
	{
		protected MyAnimeListMethods(ICredentialContext credentialContext)
		{
			CredentialContext = credentialContext;
		}

		public ICredentialContext CredentialContext { get; set; }

		/// <summary>
		///     Template method to return response text
		/// </summary>
		protected string GetResponseText(RequestParameters requestParameters)
		{
			var requestBuilder = new WebRequestBuilder(requestParameters);
			var request = requestBuilder.BuildWebRequest();

			using (var response = request.GetResponse() as HttpWebResponse)
			using (var responseStream = response.GetResponseStream())
			using (var reader = new StreamReader(responseStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}