using System;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeListMethodsTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private const int ID = 28907;

		private static readonly string _data =
			@"<?xml version = ""1.0"" encoding = ""UTF-8""?>
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
				</entry>";

		public AnimeListMethodsTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
			: base(credentialContextFixture)
		{
			_output = output;
		}

		[Fact]
		public void TestAddAnimeRequestParametersMethod()
		{
			var sut = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, ID, _data);

			Assert.Equal("POST", sut.HttpMethod);
		}

		[Fact]
		public void TestAddAnimeRequestParametersBaseUri()
		{
			var requestParameters = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, ID, _data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"http://myanimelist.net/api/animelist/add/{ID}.xml", actualUri);
		}

		[Fact]
		[Trait("Priority", "1")]
		public void TestAddAnimeRequestResponseContainsCreated()
		{
			var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);

			const string expectedSubstring = "Created";
			var actualString = sut.AddAnime(ID, _data);
			Assert.Contains(expectedSubstring, actualString);
		}

		[Fact]
		[Trait("Priority", "2")]
		public void TestUpdateAnimeRequestReturnsUpdatedText()
		{
			var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);

			var actualResponseString = sut.UpdateAnime(ID, _data);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		[Trait("Priority", "3")]
		public void TestDeleteAnimeRequest()
		{
			var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);

			var actualResponseString = sut.DeleteAnime(ID);
			_output.WriteLine("Actual: {0}", actualResponseString);

			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
