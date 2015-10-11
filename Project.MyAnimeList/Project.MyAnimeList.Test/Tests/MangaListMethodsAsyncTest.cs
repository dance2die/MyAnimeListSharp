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
		private ITestOutputHelper _output;
		private MangaValuesFixture _mangaValuesFixture;
		private MangaListMethodsAsyncFixture _mangaListMethodsAsyncFixture;

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
	}
}
