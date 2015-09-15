using System;
using System.Collections.Generic;
using System.IO;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
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
		[InvalidResponseStringData]
		public void DeserializingInvalidMangaResponseStringThrowsException(string responseString)
		{
			var sut = _mangaSearchResponseDeserializerFixture.Deserializer;

			Assert.Throws<InvalidOperationException>(() => sut.Deserialize(responseString));
		}

		[Theory]
		[MemberData("ValidMangaSearchResponseStrings")]
		public void ValidMangaResponseStringIsDeserializedAsMangaSearchResponseObjectInstance(string responseString)
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
}
