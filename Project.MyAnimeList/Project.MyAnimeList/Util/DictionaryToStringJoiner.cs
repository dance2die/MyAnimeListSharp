using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.MyAnimeList.Util
{
	public class DictionaryToStringJoiner
	{
		public string Join(IDictionary<string, string> parameters, string separator = "&")
		{
			var array = (from key in parameters.Keys
				let value = parameters[key]
				orderby key
				where string.IsNullOrWhiteSpace(value) == false
				select $"{Uri.EscapeDataString(key)}={Uri.EscapeDataString(value)}").ToArray();

			return string.Join(separator, array);
		}
	}
}