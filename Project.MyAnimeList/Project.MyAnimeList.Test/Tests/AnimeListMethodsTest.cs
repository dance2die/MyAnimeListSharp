using System;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

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
			var sut = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);

			Assert.Equal("POST", sut.HttpMethod);
		}

		[Fact]
		public void AddAnimeRequestParametersBaseUriIsBuiltBasedOnIdPassed()
		{
			var requestParameters = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"http://myanimelist.net/api/animelist/add/{AnimeValuesFixture.AnimeId}.xml", actualUri);
		}

		[Fact]
		public void AddAnimeRequestResponseContainsCreatedText()
		{
			var sut = _animeListMethodsFixture.AnimeListMethods;

			const string expectedSubstring = "Created";
			var actualString = sut.AddAnime(AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);

			Assert.Contains(expectedSubstring, actualString);
		}

		[Fact]
		public void AddAnimeUsingAnimeValuesObjectInstance()
		{
			var sut = _animeListMethodsFixture.AnimeListMethods;

			const string expectedSubstring = "Created";
			var actualString = sut.AddAnime(AnimeValuesFixture.AnimeId, _animeValuesFixture.Values);

			Assert.Contains(expectedSubstring, actualString);
		}

		[Fact]
		public void UpdateAnimeRequestReturnsUpdatedText()
		{
			var sut = _animeListMethodsFixture.AnimeListMethods;

			var actualResponseString = sut.UpdateAnime(AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		public void UpdateAnimeUsingAnimeValuesObjectInstance()
		{
			var sut = _animeListMethodsFixture.AnimeListMethods;

			var actualResponseString = sut.UpdateAnime(AnimeValuesFixture.AnimeId, _animeValuesFixture.Values);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		public void DeleteAnimeRequestReturnsDeletedText()
		{
			var sut = _animeListMethodsFixture.AnimeListMethods;

			var actualResponseString = sut.DeleteAnime(AnimeValuesFixture.AnimeId);
			_output.WriteLine("Actual: {0}", actualResponseString);

			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
