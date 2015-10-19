using System.IO;
using System.Xml.Serialization;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	public class MangaSearchResponseXmlFormatter : IFormatter<MangaSearchResponse>
	{
		public string Format(MangaSearchResponse value)
		{
			// http://stackoverflow.com/a/11448270/4035
			using (var stringwriter = new StringWriter())
			{
				var serializer = new XmlSerializer(value.GetType());
				serializer.Serialize(stringwriter, value);
				return stringwriter.ToString();
			}
		}
	}
}