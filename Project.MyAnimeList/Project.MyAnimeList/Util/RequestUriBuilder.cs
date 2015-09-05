using System.Collections.Generic;
using MyAnimeListSharp.Web;

namespace MyAnimeListSharp.Util
{
	public class RequestUriBuilder
	{
		private readonly RequestParameters _requestParameters;

		public RequestUriBuilder(RequestParameters requestParameters)
		{
			_requestParameters = requestParameters;
		}

		public string GetRequestUri()
		{
			var queryString = GetEncodedString(_requestParameters.QueryProperties);
			if (string.IsNullOrWhiteSpace(queryString) && !_requestParameters.Id.HasValue)
				return _requestParameters.BaseUri;

			string relativeUri = _requestParameters.Id.HasValue ? $"/{_requestParameters.Id.Value}.xml" : string.Empty;
			string queryUri = string.IsNullOrWhiteSpace(queryString) ? string.Empty : $"?{queryString}";
            //return $"{new Uri(new Uri(_requestParameters.BaseUri), relativeUri).AbsoluteUri}{queryUri}";
			return $"{_requestParameters.BaseUri}{relativeUri}{queryUri}";
		}

		private string GetEncodedString(IDictionary<string, string> dictionary)
		{
			return new DictionaryToStringJoiner().Join(dictionary);
		}
	}
}