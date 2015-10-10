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

	}
}
