using System.Xml.Linq;
using MyAnimeListSharp.Formatters;
using MyAnimeListSharp.Util;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class XmlFormatterTest
	{
		private readonly IXmlFormatter _xmlFormatter;

		public XmlFormatterTest()
		{
			_xmlFormatter = new DefaultXmlFormatter();
		}

		[Fact]
		public void TestDefaultXmlFormatter()
		{
			var sut = _xmlFormatter;

			XDeclaration declaration = new XDeclaration("1.0", "UTF-8", null);
			XElement content = new XElement("root", new XElement("person", 1));
			XDocument document = new XDocument(declaration, content);

			string xmlString = sut.Format(document);

			string expected =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<root>
  <person>1</person>
</root>";
			Assert.Equal(expected, xmlString);
		}
	}
}
