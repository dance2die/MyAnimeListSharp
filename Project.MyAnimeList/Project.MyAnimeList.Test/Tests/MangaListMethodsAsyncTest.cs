using System;
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
		private readonly MangaValuesFixture _mangaValuesFixture;
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

			string actual = await sut.AddMangaAsync(MangaValuesFixture.ID, MangaValuesFixture.Data);

			_output.WriteLine(actual);

			// If no record was added, then a unique ID returned,
			int uniqueId;
			bool isNumber = int.TryParse(actual, out uniqueId);

			// If already added, an error message containing MangaValue ID is returned.
		    string expectedError = $"The manga (id: {MangaValuesFixture.ID}) is already in the list.";
		    bool isAlreadyCreated = actual == expectedError;

			Assert.True(isNumber || isAlreadyCreated);
		}

		[Fact]
		public async void AddMangaUsingMangaValuesObjectInstance()
		{
			var sut = _mangaListMethodsAsyncFixture.MangaListMethods;

			const string expectedSubstring = "Created";
			string actualResponseString = await sut.AddMangaAsync(MangaValuesFixture.ID, _mangaValuesFixture.Values);

			_output.WriteLine(actualResponseString);

			// If no record was added, then a unique ID returned,
			int uniqueId;
			bool isNumber = int.TryParse(actualResponseString, out uniqueId);
			// Else "201 Created" response is returned.
			bool hasCreatedTextInIt = actualResponseString.Contains(expectedSubstring);

			Assert.True(isNumber || hasCreatedTextInIt);
		}

		[Fact]
		public async void UpdateMangaRequestReturnsUpdatedText()
		{
			var sut = _mangaListMethodsAsyncFixture.MangaListMethods;

			string actualResponseString = await sut.UpdateMangaAsync(MangaValuesFixture.ID, MangaValuesFixture.Data);

			_output.WriteLine("Actual: {0}", actualResponseString);
			Assert.Equal("Updated", actualResponseString);
		}

		[Fact]
		public async void UpdateMangaUsingMangaValuesObjectInstance()
		{
			var sut = _mangaListMethodsAsyncFixture.MangaListMethods;

			string actualResponseString = await sut.UpdateMangaAsync(MangaValuesFixture.ID, _mangaValuesFixture.Values);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Fact]
		public async void DeleteMangaRequestReturnsDeletedText()
		{
			var sut = _mangaListMethodsAsyncFixture.MangaListMethods;

			string actualResponseString = await sut.DeleteMangaAsync(MangaValuesFixture.ID);

			_output.WriteLine("Actual: {0}", actualResponseString);
			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
