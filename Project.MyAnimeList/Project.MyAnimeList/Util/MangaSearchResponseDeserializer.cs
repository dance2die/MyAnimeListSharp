using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Util
{
	public class MangaSearchResponseDeserializer
	{
		/// <summary>
		/// Parses Anime search result string
		/// </summary>
		/// <remarks>http://stackoverflow.com/a/4085745/4035</remarks>
		public MangaSearchResponse Deserialize(string responseString)
		{
			using (var stringReader = new StringReader(responseString))
			using (var xmlReader = XmlReader.Create(stringReader, new XmlReaderSettings { DtdProcessing = DtdProcessing.Ignore }))
			{
				DisableUndeclaredEntityCheck(xmlReader);

				var xmlSerializer = new XmlSerializer(typeof(MangaSearchResponse));
				var result = xmlSerializer.Deserialize(xmlReader) as MangaSearchResponse;
				return result;
			}
		}

		/// <summary>
		/// Using reflection, disable undeclared XML entity check for the specified XML reader.
		/// </summary>
		/// <remarks>http://stackoverflow.com/a/22787825/4035</remarks>
		private static void DisableUndeclaredEntityCheck(XmlReader xmlReader)
		{
			PropertyInfo propertyInfo = xmlReader.GetType().GetProperty(
				"DisableUndeclaredEntityCheck", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			propertyInfo.SetValue(xmlReader, true);
		}
	}
}