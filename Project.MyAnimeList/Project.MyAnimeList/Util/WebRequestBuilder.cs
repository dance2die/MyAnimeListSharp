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
		/// 
		/// http://www.useragentstring.com/pages/Internet%20Explorer/
		/// </summary>
		private const string USER_AGENT =
			"Mozilla/5.0 (Windows; U; MSIE 9.0; WIndows NT 9.0; en-US))";

		private const string CONTENT_TYPE = "application/x-www-form-urlencoded";

		private readonly RequestParameters _requestParameters;

		public WebRequestBuilder(RequestParameters requestParameters)
		{
			_requestParameters = requestParameters;
		}

		public HttpWebRequest BuildWebRequest()
		{
			var requestUri = new RequestUriBuilder(_requestParameters).GetRequestUri();
			var result = WebRequest.Create(requestUri) as HttpWebRequest;
			if (result == null)
				throw new InvalidOperationException("Could not create web request");

			SetWebRequestProperties(result);

			WritePostBody(result);

			return result;
		}

		public async Task<HttpWebRequest> BuildWebRequestAsync()
		{
			var requestUri = new RequestUriBuilder(_requestParameters).GetRequestUri();
			var result = WebRequest.Create(requestUri) as HttpWebRequest;
			if (result == null)
				throw new InvalidOperationException("Could not create web request");

			SetWebRequestProperties(result);

			await WritePostBodyAsync(result);

			return result;
		}

		private void SetWebRequestProperties(HttpWebRequest webRequest)
		{
			webRequest.UserAgent = USER_AGENT;
			webRequest.ContentType = CONTENT_TYPE;

			// credit
			// https://github.com/DeadlyEmbrace/MyAnimeListAPI/blob/master/MyAnimeListAPI/MyAnimeListAPI/Credentials.cs
			webRequest.Method = _requestParameters.HttpMethod;
			webRequest.UseDefaultCredentials = false;
			webRequest.Credentials = new NetworkCredential(
				_requestParameters.Credential.UserName, _requestParameters.Credential.Password);

			// credit
			// https://github.com/LHCGreg/mal-api/blob/f6c82c95d139807a1d6259200ec7622384328bc3/MalApi/MyAnimeListApi.cs
			webRequest.AutomaticDecompression = DecompressionMethods.GZip;
		}

		private void WritePostBody(HttpWebRequest request)
		{
			var postBody = GetJoinedString(_requestParameters.PostBodyProperties);
			if (string.IsNullOrWhiteSpace(postBody)) return;

			using (var requestStream = request.GetRequestStream())
			{
				var content = Encoding.ASCII.GetBytes(postBody);
				requestStream.Write(content, 0, content.Length);
			}
		}

		private async Task WritePostBodyAsync(HttpWebRequest request)
		{
			var postBody = GetJoinedString(_requestParameters.PostBodyProperties);
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