using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.MyAnimeList.Util
{
	public class DictionaryToStringJoiner
	{
		public string Join(IDictionary<string, string> parameters, string separator = "&")
		{
			return Join(parameters, Uri.EscapeDataString, separator);
		}

		public string Join(IDictionary<string, string> parameters, Func<string, string> encode, string separator = "&")
		{
			var array = (from key in parameters.Keys
				let value = parameters[key]
				orderby key
				where string.IsNullOrWhiteSpace(value) == false
				select $"{encode(key)}={encode(value)}").ToArray();

			return string.Join(separator, array);
		}
	}
}