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
