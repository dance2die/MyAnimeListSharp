using MyAnimeListSharp.Facade.Async;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaSearchMethodsTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;
		private readonly MangaSearchMethods _sut;

		public MangaSearchMethodsTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output) 
			: base(credentialContextFixture)
		{
			_output = output;
			_sut = new MangaSearchMethods(credentialContextFixture.CredentialContext);
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
	}
}
