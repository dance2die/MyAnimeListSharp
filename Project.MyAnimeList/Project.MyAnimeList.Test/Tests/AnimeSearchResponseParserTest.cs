using System.Collections.Generic;
using System.IO;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeSearchResponseParserTest : 
		IClassFixture<SearchMethodsFixture>,
		IClassFixture<AnimeSearchResponseDeserializerFixture>
	{
		private readonly SearchMethodsFixture _searchMethodsFixture;
		private readonly AnimeSearchResponseDeserializerFixture _animeSearchResponseDeserializerFixture;

		/// <summary>
		/// A collection of invalid anime response strings
		/// </summary>
		public static IEnumerable<object[]> InvalidAnimeResponseStrings
		{
			get
			{
				yield return new object[] { "<root></root>" };
				yield return new object[] { "This is not an XML string" };
			}
		}

		public AnimeSearchResponseParserTest(
			SearchMethodsFixture searchMethodsFixture,
			AnimeSearchResponseDeserializerFixture animeSearchResponseDeserializerFixture)
		{
			_searchMethodsFixture = searchMethodsFixture;
			_animeSearchResponseDeserializerFixture = animeSearchResponseDeserializerFixture;
		}

		[Theory]
		[MemberData("InvalidAnimeResponseStrings")]
		public void InvalidAnimeResponseStringCannotBeParsed(string testXmlString)
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			bool isParsable = sut.IsDeserializable(testXmlString);

			Assert.False(isParsable);
		}

		[Fact]
		public void AnimeResponseStringIsDeserializable()
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			var validResponseString = GetValidSampleAnimeSearchResponseString();
			bool isParsable = sut.IsDeserializable(validResponseString);

			Assert.True(isParsable);
		}

		[Fact]
		public void ValidAnimeResponseStringIsDeserializedAsAnimeSearchResponseObjectInstance()
		{
			var sut = _animeSearchResponseDeserializerFixture.Deserializer;

			var validResponseString = GetValidSampleAnimeSearchResponseString();
			AnimeSearchResponse response = sut.Deserialize(validResponseString);

			Assert.IsType<AnimeSearchResponse>(response);
		}

		private string GetValidSampleAnimeSearchResponseString()
		{
			const string filePath = @"./Xml/SampleAnimeSearchResponse.xml";
			var result = File.ReadAllText(filePath);

			return result;
		}
	}
}
