using System;
using MyAnimeListSharp.Parameters;
using MyAnimeListSharp.Util;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaListMethodsTest : 
		CredentialCollectionTest, 
		IClassFixture<MangaValuesFixture>,
		IClassFixture<MangaListMethodsFixture>
	{
		private readonly ITestOutputHelper _output;
		private readonly MangaValuesFixture _mangaValuesFixture;
		private readonly MangaListMethodsFixture _mangaListMethodsFixture;

		public MangaListMethodsTest(
			CredentialContextFixture credentialContextFixture, 
			ITestOutputHelper output,
			MangaValuesFixture mangaValuesFixture,
			MangaListMethodsFixture mangaListMethodsFixture)
			: base(credentialContextFixture)
		{
			_output = output;
			_mangaValuesFixture = mangaValuesFixture;
			_mangaListMethodsFixture = mangaListMethodsFixture;
		}

		[Fact]
		public void AddMangaRequestParametersMethodReturnsPostHttpMethod()
		{
			var sut = new AddMangaRequestParameters(CredentialContextFixture.CredentialContext, MangaValuesFixture.ID, MangaValuesFixture.Data);

		    const string expected = "GET";
		    Assert.Equal(expected, sut.HttpMethod);
		}

		[Fact]
		public void TestAddMangaRequestParametersBaseUri()
		{
			var requestParameters = new AddMangaRequestParameters(CredentialContextFixture.CredentialContext, MangaValuesFixture.ID, MangaValuesFixture.Data);
			var sut = new RequestUriBuilder(requestParameters);

			var actualUri = sut.GetRequestUri();

			Assert.Equal($"https://myanimelist.net/api/mangalist/add/{MangaValuesFixture.ID}.xml", actualUri);
		}

		[Fact]
		public void AddMangaRequestResponseReturnsUniqueRowId()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.AddManga(MangaValuesFixture.ID, MangaValuesFixture.Data);

			_output.WriteLine(actualResponseString);

			// If no record was added, then a unique ID returned,
			int uniqueId;
			bool isNumber = int.TryParse(actualResponseString, out uniqueId);
			// Else "201 Created" response is returned.
			bool hasCreatedTextInIt = actualResponseString.Contains("Created");

			Assert.True(isNumber || hasCreatedTextInIt);
		}

		[Fact]
		public void AddMangaUsingMangaValuesObjectInstance()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.AddManga(MangaValuesFixture.ID, _mangaValuesFixture.Values);

			// If no record was added, then a unique ID returned,
			int uniqueId;
			bool isNumber = int.TryParse(actualResponseString, out uniqueId);
            // Else "201 Created" response is returned.

            string alreadyExistsText = $"The manga (id: {MangaValuesFixture.ID}) is already in the list.";
		    bool isMangaAlreadyAdded = actualResponseString == alreadyExistsText;

			Assert.True(isNumber || isMangaAlreadyAdded);
		}

		[Fact]
		public void UpdateMangaRequestReturnsUpdatedText()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.UpdateManga(MangaValuesFixture.ID, MangaValuesFixture.Data);

			_output.WriteLine("Actual: {0}", actualResponseString);
			Assert.Equal("Updated", actualResponseString);
		}

		[Fact]
		public void UpdateMangaUsingMangaValuesObjectInstance()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.UpdateManga(MangaValuesFixture.ID, _mangaValuesFixture.Values);
			_output.WriteLine("Actual: {0}", actualResponseString);

			const string expected = "Updated";
			Assert.True(string.Compare(expected, actualResponseString, StringComparison.InvariantCultureIgnoreCase) == 0);
		}


		[Fact]
		public void DeleteMangaRequestReturnsDeletedText()
		{
			var sut = _mangaListMethodsFixture.MangaListMethods;

			var actualResponseString = sut.DeleteManga(MangaValuesFixture.ID);

			_output.WriteLine("Actual: {0}", actualResponseString);
			Assert.Equal("Deleted", actualResponseString);
		}
	}
}
