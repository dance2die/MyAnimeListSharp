using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaSearchResponseDeserializerTest : IClassFixture<MangaSearchResponseDeserializerFixture>
	{
		private readonly MangaSearchResponseDeserializerFixture _mangaSearchResponseDeserializerFixture;

		/// <summary>
		/// A collection of VALID anime response strings
		/// </summary>
		public static IEnumerable<object> ValidMangaSearchResponseStrings
		{
			get
			{
				yield return new object[] { GetValidSampleMangaSearchResponseStringFromFile() };
				yield return new object[] { GetValidSampleMangaSearchResponseStringFromWeb() };
			}
		}

		public MangaSearchResponseDeserializerTest(MangaSearchResponseDeserializerFixture mangaSearchResponseDeserializerFixture)
		{
			_mangaSearchResponseDeserializerFixture = mangaSearchResponseDeserializerFixture;
		}

		[Theory]
		[MemberData("ValidMangaSearchResponseStrings")]
		public void ValidAnimeResponseStringIsDeserializedAsAnimeSearchResponseObjectInstance(string responseString)
		{
			var sut = _mangaSearchResponseDeserializerFixture.Deserializer;

			MangaSearchResponse response = sut.Deserialize(responseString);

			Assert.IsType<MangaSearchResponse>(response);
		}


		private static string GetValidSampleMangaSearchResponseStringFromFile()
		{
			const string filePath = @"./Xml/SampleMangaSearchResponse.xml";
			var result = File.ReadAllText(filePath);

			return result;
		}

		private static string GetValidSampleMangaSearchResponseStringFromWeb()
		{
			return new SearchMethods(new CredentialContext()).SearchManga("Full metal");
		}

	}

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

	[Serializable, XmlRoot("manga")]
	public class MangaSearchResponse
	{
		[XmlElement("entry")]
		public List<MangaEntry> Entries { get; set; } = new List<MangaEntry>();
	}

	public class MangaEntry
	{
		[XmlElement(ElementName = "id")]
		public int Id { get; set; }

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "english")]
		public string English { get; set; }

		[XmlElement(ElementName = "synonyms")]
		public string Synonyms { get; set; }

		[XmlElement(ElementName = "chapters")]
		public int Chapters { get; set; }

		[XmlElement(ElementName = "volumes")]
		public int Volumes { get; set; }

		[XmlElement(ElementName = "score")]
		public double Score { get; set; }

		[XmlElement(ElementName = "type")]
		public string Type { get; set; }

		[XmlElement(ElementName = "status")]
		public string Status { get; set; }

		[XmlElement(ElementName = "start_date")]
		public string StartDate { get; set; }

		[XmlElement(ElementName = "end_date")]
		public string EndDate { get; set; }

		[XmlElement(ElementName = "synopsis")]
		public string Synopsis { get; set; }

		[XmlElement(ElementName = "image")]
		public string Image { get; set; }
	}
}
