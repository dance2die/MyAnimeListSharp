using System.Collections.Generic;
using Project.MyAnimeList.Util;

namespace Project.MyAnimeList.Web
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
			if (string.IsNullOrWhiteSpace(queryString))
				return _requestParameters.BaseUri;
			return $"{_requestParameters.BaseUri}?{queryString}";
		}

		private string GetEncodedString(IDictionary<string, string> dictionary)
		{
			return new DictionaryToStringJoiner().Join(dictionary);
		}
	}
}