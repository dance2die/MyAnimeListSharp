using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Schema;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaSearchResponseDeserializerTest : IClassFixture<MangaSearchResponseDeserializerFixture>
	{
		private readonly MangaSearchResponseDeserializerFixture _mangaSearchResponseDeserializerFixture;

		public MangaSearchResponseDeserializerTest(MangaSearchResponseDeserializerFixture mangaSearchResponseDeserializerFixture)
		{
			_mangaSearchResponseDeserializerFixture = mangaSearchResponseDeserializerFixture;
		}

		//[Theory]
		//[MemberData("InvalidAnimeResponseStrings")]
		//public void InvalidAnimeResponseStringCannotBeParsed(string responseString)
		//{
		//	var sut = _mangaSearchResponseDeserializerFixture.Deserializer;

		//	bool isParsable = sut.IsDeserializable(responseString);

		//	Assert.False(isParsable);
		//}
	}

	public class MangaSearchResponseDeserializer
	{
		public bool IsDeserializable(string testString)
		{
			if (string.IsNullOrWhiteSpace(testString)) return false;

			using (StringReader reader = new StringReader(testString))
			{
				XDocument document;
				try
				{
					document = XDocument.Load(reader);
				}
				catch (Exception ex)
				{
					return false;
				}

				bool error = false;
				var xmlSchemaSet = GetXmlSchemaSet();
				document.Validate(xmlSchemaSet,
					// Closure: Access "error" variable from outer scope to set the return value.
					// This event handler is called only when a validation error occurs.
					(sender, args) => error = true);

				return !error;
			}
		}

		private XmlSchemaSet GetXmlSchemaSet()
		{
			var result = new XmlSchemaSet();
			const string targetNamespace = "";
			string schemaUri = @"./Xml/MangaSearchResponse.xsd";

			result.Add(targetNamespace, schemaUri);
			return result;
		}
	}

	public class MangaSearchResponseDeserializerFixture
	{
		public MangaSearchResponseDeserializer Deserializer { get; set; } = new MangaSearchResponseDeserializer();
	}
}
