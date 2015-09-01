using System;
using System.Net;

namespace Project.MyAnimeList
{
	public static class WebRequestBuilder
	{
		public static HttpWebRequest BuildWebRequest(RequestParameters requestParameters)
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
}