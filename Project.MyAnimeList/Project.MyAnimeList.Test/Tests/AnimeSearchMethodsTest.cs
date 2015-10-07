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
	public class AnimeSearchMethodsTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;
		private readonly AnimeSearchMethods _sut;

		public AnimeSearchMethodsTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output) 
			: base(credentialContextFixture)
		{
			_output = output;
			_sut = new AnimeSearchMethods(credentialContextFixture.CredentialContext);
		}

		[Theory]
		[InlineData("Naruto")]
		[InlineData("Full Metal")]
		public async void SearchAsyncReturnValueIsNotEmpty(string searchTerm)
		{
			string response = await _sut.SearchAsync(searchTerm);

			_output.WriteLine(response);
			Assert.False(string.IsNullOrEmpty(response));
		}

	}
}
