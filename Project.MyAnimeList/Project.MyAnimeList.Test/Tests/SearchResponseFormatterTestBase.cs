using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace Project.MyAnimeList.Test.Tests
{
	public class SearchResponseFormatterTestBase
	{
		protected bool IsParsableJson(string jsonText)
		{
			try
			{
				JObject.Parse(jsonText);
				return true;
			}
			catch
			{
				return false;
			}
		}

		protected bool IsParsableXml(string xmlText)
		{
			try
			{
				// http://stackoverflow.com/a/18704859/4035
				XDocument.Parse(xmlText);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}