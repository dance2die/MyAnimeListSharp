using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade.Async;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaSearchMethodsAsyncTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;
		private readonly MangaSearchMethodsAsync _sut;

		public MangaSearchMethodsAsyncTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output) 
			: base(credentialContextFixture)
		{
			_output = output;
			_sut = new MangaSearchMethodsAsync(credentialContextFixture.CredentialContext);
		}

		[Theory]
		[InlineData("Naruto")]
		[InlineData("One Piece")]
		public async void SearchAsyncResponseIsNotEmpty(string searchTerm)
		{
			string response = await _sut.SearchAsync(searchTerm);

			_output.WriteLine(response);
			Assert.False(string.IsNullOrWhiteSpace(response));
		}

		[Theory]
		[InlineData("Attack on Titan")]
		[InlineData("Code Geass")]
		[InlineData("Naruto")]
		public async void SearchDeserializedAsyncResponseHasEntries(string searchTerm)
		{
			MangaSearchResponse response = await _sut.SearchDeserializedAsync(searchTerm);

			_output.WriteLine($"response.Entries.Count = {response.Entries.Count}");
			Assert.True(response.Entries.Count > 0);
		}

		[Theory]
		[InlineData("a;dlsfjasdf")]
		[InlineData("xyzopqrstu")]
		public async void SearchDeserializedAsyncResponseHasNoEntry(string searchTerm)
		{
			MangaSearchResponse response = await _sut.SearchDeserializedAsync(searchTerm);

			_output.WriteLine($"response.Entries.Count = {response.Entries.Count}");
			Assert.True(response.Entries.Count == 0);
		}
	}
}
