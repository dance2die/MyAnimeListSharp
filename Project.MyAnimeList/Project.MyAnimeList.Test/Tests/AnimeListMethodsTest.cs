using System;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;
using Assert = Xunit.Assert;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeListMethodsTest : 
		CredentialCollectionTest, 
		IClassFixture<AnimeValuesFixture>, 
		IClassFixture<AnimeListMethodsFixture>
	{
		private readonly ITestOutputHelper _output;
		private readonly AnimeValuesFixture _animeValuesFixture;
		private readonly AnimeListMethodsFixture _animeListMethodsFixture;

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private const int ID = 28907;
		private const string XML_DECLARATION = @"<?xml version=""1.0"" encoding=""UTF-8""?>";

		private static readonly string _data = XML_DECLARATION +
			@"
				<entry>
					<episode>1</episode>
					<status>2</status>
					<score>3</score>
					<downloaded_episodes>4</downloaded_episodes>
					<storage_type>5</storage_type>
					<storage_value>6</storage_value>
					<times_rewatched>7</times_rewatched>
					<rewatch_value>8</rewatch_value>
					<date_start>01302015</date_start>
					<date_finish>07312015</date_finish>
					<priority>1</priority>
					<enable_discussion>1</enable_discussion>
					<enable_rewatching>1</enable_rewatching>
					<comments>This is a comment</comments>
					<fansub_group>Horrible Subs</fansub_group>
					<tags>Test Tag1, Test Tag2</tags>
				</entry>";

		public AnimeListMethodsTest(
			CredentialContextFixture credentialContextFixture, 
			ITestOutputHelper output, 
			AnimeValuesFixture animeValuesFixture,
			AnimeListMethodsFixture animeListMethodsFixture)
			: base(credentialContextFixture)
		{
			_output = output;
			_animeValuesFixture = animeValuesFixture;
			_animeListMethodsFixture = animeListMethodsFixture;
		}

		[Fact]
		public void AddAnimeRequestParametersMethodIsPost()
		{
			var sut = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, ID, _data);

			Assert.Equal("POST", sut.HttpMethod);
		}

		[Fact]
		public void AddAnimeRequestParametersBaseUriIsBuiltBasedOnIdPassed()
		{
			var requestParameters = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, ID, _data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"http://myanimelist.net/api/animelist/add/{ID}.xml", actualUri);
		}

		[Fact]
		public void AddAnimeRequestResponseContainsCreatedText()
		{
			//var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);
			var sut = _animeListMethodsFixture.AnimeListMethods;

			const string expectedSubstring = "Created";
			var actualString = sut.AddAnime(ID, _data);
			Assert.Contains(expectedSubstring, actualString);
		}

		//[Fact]
		//public void AddAnimeUsingAnimeValuesObjectInstance()
		//{
			
		//}

		[Fact]
		public void UpdateAnimeRequestReturnsUpdatedText()
		{
			//var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);
			var sut = _animeListMethodsFixture.AnimeListMethods;

			var actualResponseString = sut.UpdateAnime(ID, _data);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		public void DeleteAnimeRequestReturnsDeletedText()
		{
			//var sut = new AnimeListMethods(CredentialContextFixture.CredentialContext);
			var sut = _animeListMethodsFixture.AnimeListMethods;

			var actualResponseString = sut.DeleteAnime(ID);
			_output.WriteLine("Actual: {0}", actualResponseString);

			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
