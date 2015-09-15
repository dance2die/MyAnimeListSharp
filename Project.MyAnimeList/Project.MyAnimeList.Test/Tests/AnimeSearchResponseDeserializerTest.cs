using System;
using System.Collections.Generic;
using System.IO;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeSearchResponseDeserializerTest : IClassFixture<AnimeSearchResponseDeserializerFixture>
	{
		private readonly AnimeSearchResponseDeserializerFixture _animeSearchResponseDeserializerFixture;

		/// <summary>
		/// A collection of VALID anime response strings
		/// </summary>
		public static IEnumerable<object> ValidAnimeSearchResponseStrings
		{
			get
			{
				yield return new object[] { GetValidSampleAnimeSearchResponseStringFromFile() };
				yield return new object[] { GetValidSampleAnimeSearchResponseStringFromWeb() };
			}
		}

		public AnimeSearchResponseDeserializerTest(AnimeSearchResponseDeserializerFixture animeSearchResponseDeserializerFixture)
		{
			_animeSearchResponseDeserializerFixture = animeSearchResponseDeserializerFixture;
		}

		[Theory]
		[InvalidResponseStringData]
		public void DeserializingInvalidMangaResponseStringThrowsException(string responseString)
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			Assert.Throws<InvalidOperationException>(() => sut.Deserialize(responseString));
		}

		[Theory]
		[MemberData("ValidAnimeSearchResponseStrings")]
		public void ValidAnimeResponseStringIsDeserializedAsAnimeSearchResponseObjectInstance(string responseString)
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			AnimeSearchResponse response = sut.Deserialize(responseString);

			Assert.IsType<AnimeSearchResponse>(response);
		}

		private static string GetValidSampleAnimeSearchResponseStringFromFile()
		{
			const string filePath = @"./Xml/SampleAnimeSearchResponse.xml";
			var result = File.ReadAllText(filePath);

			return result;
		}

		private static string GetValidSampleAnimeSearchResponseStringFromWeb()
		{
			return new SearchMethods(new CredentialContext()).SearchAnime("Full metal");
		}
	}
}
