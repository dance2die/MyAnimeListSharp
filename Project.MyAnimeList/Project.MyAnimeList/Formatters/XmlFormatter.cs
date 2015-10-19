using System.IO;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Formatters
{
	public class XmlFormatter<T> : IFormatter<T>
	{
		public string Format(T value)
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