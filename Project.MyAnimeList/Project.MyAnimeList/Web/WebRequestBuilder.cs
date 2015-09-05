using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Web
{
	internal class WebRequestBuilder
	{
		public RequestParameters RequestParameters { get; set; }

		public WebRequestBuilder(RequestParameters requestParameters)
		{
			RequestParameters = requestParameters;
		}

		public HttpWebRequest BuildWebRequest()
		{
			string requestUri = new RequestUriBuilder(RequestParameters).GetRequestUri();
			HttpWebRequest result = WebRequest.Create(requestUri) as HttpWebRequest;
			if (result == null)
				throw new InvalidOperationException("Could not create web request");

			result.ContentType = "application/x-www-form-urlencoded";

			// credit
			// https://github.com/DeadlyEmbrace/MyAnimeListAPI/blob/master/MyAnimeListAPI/MyAnimeListAPI/Credentials.cs
			result.Method = RequestParameters.HttpMethod;
			result.UseDefaultCredentials = false;
			result.Credentials = new NetworkCredential(
				RequestParameters.Credential.UserName, RequestParameters.Credential.Password);

			// credit
			// https://github.com/LHCGreg/mal-api/blob/f6c82c95d139807a1d6259200ec7622384328bc3/MalApi/MyAnimeListApi.cs
			result.AutomaticDecompression = DecompressionMethods.GZip;

			WritePostBody(result);

			return result;
		}

		private void WritePostBody(HttpWebRequest request)
		{
			string postBody = GetJoinedString(RequestParameters.PostBodyProperties);
			if (string.IsNullOrWhiteSpace(postBody)) return;

			using (Stream requestStream = request.GetRequestStream())
			{
				byte[] content = Encoding.ASCII.GetBytes(postBody);
				requestStream.Write(content, 0, content.Length);
			}
		}

		private string GetJoinedString(IDictionary<string, string> dictionary)
		{
			// Don't encode and just return the input as it is.
			Func<string, string> doNotEncode = input => input;
			return new DictionaryToStringJoiner().Join(dictionary, doNotEncode);
		}
	}
}