using Project.MyAnimeList.Web;
using Xunit;

namespace Project.MyAnimeList.Test
{
	public class AnimeListMethodsTest : CredentialCollectionTest
	{
		public AnimeListMethodsTest(CredentialContextFixture credentialContextFixture)
			: base(credentialContextFixture)
		{
		}

		[Fact]
		public void TestAddAnimeRequestParametersMethod()
		{
			int? id = null;
			string data = string.Empty;
			var sut = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, id, data);

			Assert.Equal("POST", sut.HttpMethod);
		}

		[Fact]
		public void TestAddAnimeRequestParametersBaseUri()
		{
			int? id = 123;
			string data = string.Empty;
			var requestParameters = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, id, data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"http://myanimelist.net/api/animelist/add/{id.Value}.xml", actualUri);
		}
	}
}
