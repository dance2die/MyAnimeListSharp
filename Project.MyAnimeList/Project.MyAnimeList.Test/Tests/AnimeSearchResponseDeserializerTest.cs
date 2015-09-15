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
		/// A collection of INvalid anime response strings
		/// </summary>
		public static IEnumerable<object[]> InvalidAnimeResponseStrings
		{
			get
			{
				yield return new object[] { "<root></root>" };
				yield return new object[] { "This is not an XML string" };
			}
		}

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
		[MemberData("InvalidAnimeResponseStrings")]
		public void InvalidAnimeResponseStringCannotBeParsed(string responseString)
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			bool isParsable = sut.IsDeserializable(responseString);

			Assert.False(isParsable);
		}


		[Theory]
		[MemberData("ValidAnimeSearchResponseStrings")]
		public void AnimeResponseStringIsDeserializable(string responseString)
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			bool isParsable = sut.IsDeserializable(responseString);

			Assert.True(isParsable);
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
