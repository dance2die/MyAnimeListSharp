using System.IO;
using System.Xml.Serialization;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	public class AnimeSearchResponseXmlFormatter : IFormatter<AnimeSearchResponse>
	{
		public string Format(AnimeSearchResponse value)
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