using System.Collections.Generic;
using Project.MyAnimeList.Facade;
using Project.MyAnimeList.Util;
using Project.MyAnimeList.Web;
using Xunit;

namespace Project.MyAnimeList.Test
{
	public class SearchMethodsTest : CredentialCollectionTest
	{
		public SearchMethods SearchMethods { get; private set; }

		public SearchMethodsTest(CredentialContextFixture credentialContextFixture)
			: base(credentialContextFixture)
		{
			SearchMethods = new SearchMethods(credentialContextFixture.CredentialContext);
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
				new SearchAnimeRequestParameters(CredentialContextFixture.CredentialContext,"full metal");
			var sut = new RequestUriBuilder(requestParameters);

			var actual = sut.GetRequestUri();

			Assert.Equal("http://myanimelist.net/api/anime/search.xml?q=full%20metal", actual);
		}

		[Theory]
		[InlineData("Naruto")]
		[InlineData("Full Metal")]
		public void TestSearchAnimeReturnsNotEmpty(string searchTerm)
		{
			string response = SearchMethods.SearchAnime(searchTerm);

			Assert.False(string.IsNullOrEmpty(response));
		}
	}
}
