using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaListMethodsAsyncTest :
		CredentialCollectionTest,
		IClassFixture<MangaValuesFixture>,
		IClassFixture<MangaListMethodsAsyncFixture>
	{
		private readonly ITestOutputHelper _output;
		private MangaValuesFixture _mangaValuesFixture;
		private readonly MangaListMethodsAsyncFixture _mangaListMethodsAsyncFixture;

		public MangaListMethodsAsyncTest(
			CredentialContextFixture credentialContextFixture,
			ITestOutputHelper output,
			MangaValuesFixture mangaValuesFixture,
			MangaListMethodsAsyncFixture mangaListMethodsAsyncFixture)
				: base(credentialContextFixture)
		{
			_output = output;
			_mangaValuesFixture = mangaValuesFixture;
			_mangaListMethodsAsyncFixture = mangaListMethodsAsyncFixture;
		}

		[Fact]
		public async void AddMangaRequestResponseReturnsUniqueRowId()
		{
			var sut = _mangaListMethodsAsyncFixture.MangaListMethods;

			string actualResponseString = await sut.AddMangaAsync(MangaValuesFixture.ID, MangaValuesFixture.Data);

			_output.WriteLine(actualResponseString);

			// If no record was added, then a unique ID returned,
			int uniqueId;
			bool isNumber = int.TryParse(actualResponseString, out uniqueId);
			// Else "201 Created" response is returned.
			bool hasCreatedTextInIt = actualResponseString.Contains("Created");

			Assert.True(isNumber || hasCreatedTextInIt);
		}

	}
}
