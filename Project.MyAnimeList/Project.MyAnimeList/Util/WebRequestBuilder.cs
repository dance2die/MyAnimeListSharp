using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Util
{
	internal class WebRequestBuilder
	{
		public WebRequestBuilder(RequestParameters requestParameters)
		{
			RequestParameters = requestParameters;
		}

		public RequestParameters RequestParameters { get; set; }

		public HttpWebRequest BuildWebRequest()
		{
			var requestUri = new RequestUriBuilder(RequestParameters).GetRequestUri();
			var result = WebRequest.Create(requestUri) as HttpWebRequest;
			if (result == null)
				throw new InvalidOperationException("Could not create web request");

			result.ContentType = "application/x-www-form-urlencoded";

			// credit
			// https://github.com/DeadlyEmbrace/MyAnimeListAPI/blob/master/MyAnimeListAPI/MyAnimeListAPI/Credentials.cs
			result.Method = RequestParameters.HttpMethod;
			result.UseDefaultCredentials = false;
			result.Credentials = new NetworkCredential(
				RequestParameters.Credential.UserName, RequestParameters.Credential.Password);

			//// credit
			//// https://github.com/LHCGreg/mal-api/blob/f6c82c95d139807a1d6259200ec7622384328bc3/MalApi/MyAnimeListApi.cs
			result.AutomaticDecompression = DecompressionMethods.GZip;

			WritePostBody(result);

			return result;
		}

		private void WritePostBody(HttpWebRequest request)
		{
			var postBody = GetJoinedString(RequestParameters.PostBodyProperties);
			if (string.IsNullOrWhiteSpace(postBody)) return;

			using (var requestStream = request.GetRequestStream())
			{
				var content = Encoding.ASCII.GetBytes(postBody);
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