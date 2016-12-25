using System;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeListMethodsAsyncTest :
		CredentialCollectionTest,
		IClassFixture<AnimeValuesFixture>,
		IClassFixture<AnimeListMethodsAsyncFixture>
	{
		private readonly ITestOutputHelper _output;
		private readonly AnimeValuesFixture _animeValuesFixture;
		private readonly AnimeListMethodsAsyncFixture _animeListMethodsAsyncFixture;

		public AnimeListMethodsAsyncTest(
			CredentialContextFixture credentialContextFixture,
			ITestOutputHelper output,
			AnimeValuesFixture animeValuesFixture,
			AnimeListMethodsAsyncFixture animeListMethodsAsyncFixture)
				: base(credentialContextFixture)
		{
			_output = output;
			_animeValuesFixture = animeValuesFixture;
			_animeListMethodsAsyncFixture = animeListMethodsAsyncFixture;
		}

		[Fact]
		public async void AddAnimeRequestResponseContainsCreatedText()
		{
			var sut = _animeListMethodsAsyncFixture.AnimeListMethods;

			const string expectedSubstring = "Created";
			string actualString = await sut.AddAnimeAsync(AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);

			_output.WriteLine(actualString);
            var inListAlreadyText = $"The anime (id: {AnimeValuesFixture.AnimeId}) is already in the list.";

            if (actualString == inListAlreadyText)
                Assert.True(true);
            else
                Assert.Contains(expectedSubstring, actualString);
        }

        [Fact]
		public async void AddAnimeUsingAnimeValuesObjectInstance()
		{
			var sut = _animeListMethodsAsyncFixture.AnimeListMethods;

			const string expectedSubstring = "Created";
			string actualString = await sut.AddAnimeAsync(AnimeValuesFixture.AnimeId, _animeValuesFixture.Values);

			_output.WriteLine(actualString);
			Assert.Contains(expectedSubstring, actualString);
		}

		[Fact]
		public async void UpdateAnimeRequestReturnsUpdatedText()
		{
			var sut = _animeListMethodsAsyncFixture.AnimeListMethods;

			var actualResponseString = await sut.UpdateAnimeAsync(AnimeValuesFixture.AnimeId, AnimeValuesFixture.Data);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		public async void UpdateAnimeUsingAnimeValuesObjectInstance()
		{
			var sut = _animeListMethodsAsyncFixture.AnimeListMethods;

			string actualResponseString = await sut.UpdateAnimeAsync(AnimeValuesFixture.AnimeId, _animeValuesFixture.Values);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		public async void DeleteAnimeRequestReturnsDeletedText()
		{
			var sut = _animeListMethodsAsyncFixture.AnimeListMethods;

			string actualResponseString = await sut.DeleteAnimeAsync(AnimeValuesFixture.AnimeId);
			_output.WriteLine("Actual: {0}", actualResponseString);

			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
