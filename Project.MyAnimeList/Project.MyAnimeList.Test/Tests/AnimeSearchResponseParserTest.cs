using System.IO;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeSearchResponseParserTest : IClassFixture<SearchMethodsFixture>
	{
		public SearchMethodsFixture SearchMethodsFixture { get; set; }

		public AnimeSearchResponseParserTest(SearchMethodsFixture searchMethodsFixture)
		{
			SearchMethodsFixture = searchMethodsFixture;
		}

		[Theory]
		[InlineData("<root></root>")]
		[InlineData("This is not an XML string")]
		public void InvalidAnimeResponseStringCannotBeParsed(string testXmlString)
		{
			var sut = new AnimeSearchResponseParser();

			bool isParsable = sut.IsParsable(testXmlString);

			Assert.False(isParsable);
		}

		[Fact]
		public void AnimeResponseStringIsParsable()
		{
			var sut = new AnimeSearchResponseParser();

			var responseString = GetSampleAnimeSearchResponseString();
			bool isParsable = sut.IsParsable(responseString);

			Assert.True(isParsable);
		}

		private string GetSampleAnimeSearchResponseString()
		{
			const string filePath = @"./Xml/SampleAnimeSearchResponse.xml";
			var result = File.ReadAllText(filePath);

			return result;
		}
	}
}
