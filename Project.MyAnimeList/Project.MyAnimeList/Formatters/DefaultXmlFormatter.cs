using System.IO;
using System.Text;
using System.Xml.Linq;
using MyAnimeListSharp.Util;

namespace MyAnimeListSharp.Formatters
{
	public class DefaultXmlFormatter : IXmlFormatter
	{
		public string Format(XDocument document)
		{
			var stringBuilder = new StringBuilder();
			using (TextWriter writer = new Utf8StringWriter(stringBuilder))
			{
				document.Save(writer);
			}

			return stringBuilder.ToString();
		}
	}
}