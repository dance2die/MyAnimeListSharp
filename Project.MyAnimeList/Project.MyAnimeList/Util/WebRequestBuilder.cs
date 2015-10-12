using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MyAnimeListSharp.Parameters;

namespace MyAnimeListSharp.Util
{
	internal class WebRequestBuilder
	{
		/// <summary>
		/// http://www.useragentstring.com/pages/Chrome/
		/// Chrome 41.0.2228.0
		/// </summary>
		private const string USER_AGENT =
			"Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36";

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

			SetWebRequestProperties(result);

			WritePostBody(result);

			return result;
		}

		public async Task<HttpWebRequest> BuildWebRequestAsync()
		{
			var requestUri = new RequestUriBuilder(RequestParameters).GetRequestUri();
			var result = WebRequest.Create(requestUri) as HttpWebRequest;
			if (result == null)
				throw new InvalidOperationException("Could not create web request");

			SetWebRequestProperties(result);

			await WritePostBodyAsync(result);

			return result;
		}

		private void SetWebRequestProperties(HttpWebRequest result)
		{
			result.UserAgent = USER_AGENT;
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

		private async Task WritePostBodyAsync(HttpWebRequest request)
		{
			var postBody = GetJoinedString(RequestParameters.PostBodyProperties);
			if (string.IsNullOrWhiteSpace(postBody)) return;

			using (Stream requestStream = await Task.Factory.FromAsync<Stream>(
				request.BeginGetRequestStream, request.EndGetRequestStream, request))
			{
				var content = Encoding.ASCII.GetBytes(postBody);
				await requestStream.WriteAsync(content, 0, content.Length);
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