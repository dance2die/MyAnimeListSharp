using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade.Async;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
    /// <summary>
    /// Test to create AnimeSearchMethods, an asynchronous part of SearchMethods facade.
    /// </summary>
    /// <remarks>
    /// Create asynchronous versions of WebRequest/Response methods using following links.
    /// <see cref="https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-8#q=task.factory.fromasync%20webrequest&es_th=1"/>
    /// <see cref="http://stackoverflow.com/a/23004036/4035"/>
    /// <see cref="http://stackoverflow.com/a/14098942/4035"/>
    /// <see cref="http://stackoverflow.com/q/17664191/4035"/>
    /// </remarks>
    public class AnimeSearchMethodsAsyncTest : CredentialCollectionTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AnimeSearchMethodsAsync _sut;

        public AnimeSearchMethodsAsyncTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
            : base(credentialContextFixture)
        {
            _output = output;
            _sut = new AnimeSearchMethodsAsync(credentialContextFixture.CredentialContext);
        }

        [Theory]
        [InlineData("Naruto")]
        [InlineData("Full Metal")]
        public void SearchAsyncResponseIsNotEmpty(string searchTerm)
        {
            string response = _sut.SearchAsync(searchTerm).Result;

            _output.WriteLine(response);
            Assert.False(string.IsNullOrWhiteSpace(response));
        }

        [Theory]
        [InlineData("Attack on Titan")]
        [InlineData("Code Geass")]
        [InlineData("Naruto")]
        public async void SearchDeserializedAsyncResponseHasEntries(string searchTerm)
        {
            AnimeSearchResponse response = await _sut.SearchDeserializedAsync(searchTerm);

            _output.WriteLine($"response.Entries.Count = {response.Entries.Count}");
            Assert.True(response.Entries.Count > 0);
        }

        [Theory]
        [InlineData("Oh My Goddess")]
        [InlineData("xyzopqrstu")]
        [InlineData("a;jdf;lasj;lfjas;ldjf;lkdsajfs")]
        public async void SearchDeserializedAsyncResponseHasNoEntry(string searchTerm)
        {
            AnimeSearchResponse response = await _sut.SearchDeserializedAsync(searchTerm);

            _output.WriteLine($"response.Entries.Count = {response.Entries.Count}");
            Assert.True(response.Entries.Count == 0);
        }

        //[Theory]
        //   [InlineData("xyzopqrstu")]
        //   [InlineData("a;jdf;lasj;lfjas;ldjf;lkdsajfs")]
        //   public async void SearchingInvalidEntryReturnsEmptyResponse(string searchTerm)
        //{
        //       await Assert.ThrowsAsync<InvalidOperationException>(async () =>
        //        {
        //            AnimeSearchResponse response = await _sut.SearchDeserializedAsync(searchTerm);
        //        });
        //}
    }
}