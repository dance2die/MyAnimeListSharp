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
		public void AddAnimeRequestParametersMethodIsGet()
		{
			var sut = new AddAnimeRequestParameters(CredentialContextFixture.CredentialContext, AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);

		    const string expected = "GET";
		    Assert.Equal(expected, sut.HttpMethod);
		}

		[Fact]
		public void AddAnimeRequestParametersBaseUriIsBuiltBasedOnIdPassed()
		{
			var requestParameters = new AddAnimeRequestParameters(
                CredentialContextFixture.CredentialContext, AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);
			var sut = new RequestUriBuilder(requestParameters);

			var actual = sut.GetRequestUri();

		    var expected = $"https://myanimelist.net/api/animelist/add/{AnimeValuesFixture.AnimeId}.xml?data=%3C%3Fxml%20version%3D%221.0%22%20encoding%3D%22UTF-8%22%3F%3E%0D%0A%09%09%09%09%3Centry%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cepisode%3E11%3C%2Fepisode%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cstatus%3E1%3C%2Fstatus%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cscore%3E7%3C%2Fscore%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cstorage_type%3E5%3C%2Fstorage_type%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cstorage_value%3E6%3C%2Fstorage_value%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Ctimes_rewatched%3E7%3C%2Ftimes_rewatched%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Crewatch_value%3E8%3C%2Frewatch_value%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cdate_start%3E01302015%3C%2Fdate_start%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cdate_finish%3E07312015%3C%2Fdate_finish%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cpriority%3E1%3C%2Fpriority%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cenable_discussion%3E1%3C%2Fenable_discussion%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Cenable_rewatching%3E1%3C%2Fenable_rewatching%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Ccomments%3EThis%20is%20a%20comment%3C%2Fcomments%3E%0D%0A%09%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3Ctags%3Etest%20tag%2C%202nd%20tag%3C%2Ftags%3E%0D%0A%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%20%3C%2Fentry%3E";
		    Assert.Equal(expected, actual);
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

		    var inListAlreadyText = $"The anime (id: {AnimeValuesFixture.AnimeId}) is already in the list.";

            if (actualString == inListAlreadyText)
		        Assert.True(true);
		    else
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
