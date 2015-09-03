using System.Net;
using Project.MyAnimeList.Facade;
using Project.MyAnimeList.Web;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test
{
	public class AnimeListMethodsTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private readonly int? _id = 123;
		private readonly string _data =
			@"<? xml version = ""1.0"" encoding = ""UTF -8"" ?>
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

		public AnimeListMethodsTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
			: base(credentialContextFixture)
		{
			_output = output;
		}

		[Fact]
		public void TestAddAnimeRequestParametersMethod()
		{
			var sut = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, _id, _data);

			Assert.Equal("POST", sut.HttpMethod);
		}

		[Fact]
		public void TestAddAnimeRequestParametersBaseUri()
		{
			var requestParameters = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, _id, _data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"http://myanimelist.net/api/animelist/add/{_id.Value}.xml", actualUri);
		}

		[Fact]
		public void TestAddAnimeRequestThrowsWebExceptionForNotImplemented()
		{
			var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);

			//string uniqueId = sut.AddAnime(id, data);
			//Assert.False(string.IsNullOrEmpty(uniqueId));
			Assert.Throws<WebException>(() => sut.AddAnime(_id, _data));
		}

		[Fact]
		public void TestAddAnimeRequestUpdate()
		{
			var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);

			var actual = sut.UpdateAnime(_id, _data);

			_output.WriteLine("Actual: {0}", actual);
			Assert.False(string.IsNullOrEmpty(actual));
		}
	}
}
