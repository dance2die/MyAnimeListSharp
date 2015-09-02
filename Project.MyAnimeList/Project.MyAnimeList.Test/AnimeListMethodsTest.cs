using System.Net;
using Project.MyAnimeList.Facade;
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

		[Fact]
		public void TestAddAnimeRequestThrowsWebExceptionForNotImplemented()
		{
			// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
			// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
			int? id = 28907;
			string data = @"
<? xml version = ""1.0"" encoding = ""UTF -8"" ?>
<entry>
	<episode>9</episode>
	<status>1</status>
	<score>9</score>
	<downloaded_episodes></downloaded_episodes>
	<storage_type></storage_type>
	<storage_value></storage_value>
	<times_rewatched></times_rewatched>
	<rewatch_value></rewatch_value>
	<date_start></date_start>
	<date_finish></date_finish>
	<priority></priority>
	<enable_discussion></enable_discussion>
	<enable_rewatching></enable_rewatching>
	<comments></comments>
	<fansub_group></fansub_group>
	<tags>test tag, 2nd tag</tags>
</ entry>";
			var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);

			//string uniqueId = sut.AddAnime(id, data);
			//Assert.False(string.IsNullOrEmpty(uniqueId));
			Assert.Throws<WebException>(() => sut.AddAnime(id, data));
		}
	}
}
