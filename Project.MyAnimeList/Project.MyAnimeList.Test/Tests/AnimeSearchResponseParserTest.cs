using System.Collections.Generic;
using System.IO;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeSearchResponseParserTest : IClassFixture<SearchMethodsFixture>
	{
		public SearchMethodsFixture SearchMethodsFixture { get; set; }

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

		public AnimeSearchResponseParserTest(SearchMethodsFixture searchMethodsFixture)
		{
			SearchMethodsFixture = searchMethodsFixture;
		}

		[Theory]
		[MemberData("InvalidAnimeResponseStrings")]
		public void InvalidAnimeResponseStringCannotBeParsed(string testXmlString)
		{
			var sut = new AnimeSearchResponseDeserializer();

			bool isParsable = sut.IsDeserializable(testXmlString);

			Assert.False(isParsable);
		}

		[Fact]
		public void AnimeResponseStringIsDeserializable()
		{
			var sut = new AnimeSearchResponseDeserializer();

			var validResponseString = GetSampleAnimeSearchResponseString();
			bool isParsable = sut.IsDeserializable(validResponseString);

			Assert.True(isParsable);
		}

		[Fact]
		public void ValidAnimeResponseStringIsDeserializedAsAnimeSearchResponseObjectInstance()
		{
			var sut = new AnimeSearchResponseDeserializer();

			var validResponseString = GetSampleAnimeSearchResponseString();
			AnimeSearchResponse response = sut.Deserialize(validResponseString);

			Assert.IsType<AnimeSearchResponse>(response);
		}

		private string GetSampleAnimeSearchResponseString()
		{
			const string filePath = @"./Xml/SampleAnimeSearchResponse.xml";
			var result = File.ReadAllText(filePath);

			return result;
		}
	}
}
