using System.Collections.Generic;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Util;
using MyAnimeListSharp.Web;
using Xunit;

namespace Project.MyAnimeList.Test
{
	public class SearchMethodsTest : CredentialCollectionTest
	{
		// Sut => System Under Test
		public SearchMethods Sut { get; }

		public SearchMethodsTest(CredentialContextFixture credentialContextFixture)
			: base(credentialContextFixture)
		{
			Sut = new SearchMethods(credentialContextFixture.CredentialContext);
		}

		[Fact]
		public void TestDictionaryToStringJoiner()
		{
			var sut = new DictionaryToStringJoiner();
			IDictionary<string, string> parameters = new Dictionary<string, string>
			{
				{"q", "full metal"},
				{"q2", "naruto"},
			};

			var actual = sut.Join(parameters);

			Assert.Equal("q=full%20metal&q2=naruto", actual);
		}

		[Fact]
		public void TestRequestUriBuilder()
		{
			// I need to learn how to do mocking....
			RequestParameters requestParameters = 
				new AnimeSearchRequestParameters(CredentialContextFixture.CredentialContext,"full metal");
			var sut = new RequestUriBuilder(requestParameters);

			var actual = sut.GetRequestUri();

			Assert.Equal("http://myanimelist.net/api/anime/search.xml?q=full%20metal", actual);
		}

		[Theory]
		[InlineData("Naruto")]
		[InlineData("Full Metal")]
		public void TestSearchAnimeReturnsNotEmpty(string searchTerm)
		{
			string response = Sut.SearchAnime(searchTerm);

			Assert.False(string.IsNullOrEmpty(response));
		}

		[Theory]
		[InlineData("Naruto")]
		[InlineData("Full Metal")]
		public void TestSearchMangaReturnsNotEmpty(string searchTerm)
		{
			string response = Sut.SearchManga(searchTerm);

			Assert.False(string.IsNullOrEmpty(response));
		}
	}
}
