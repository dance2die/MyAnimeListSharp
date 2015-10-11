using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Core;
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

	public class MangaListMethodsAsyncFixture
	{
		public MangaListMethodsAsync MangaListMethods { get; set; }

		public MangaListMethodsAsyncFixture()
			: this(new CredentialContextFixture())
		{
		}

		public MangaListMethodsAsyncFixture(CredentialContextFixture credentialContextFixture)
		{
			MangaListMethods = new MangaListMethodsAsync(credentialContextFixture.CredentialContext);
		}

	}

	public class MangaListMethodsAsync : MyAnimeListMethodsAsync
	{
		public MangaListMethodsAsync(ICredentialContext credentialContext) 
			: base(credentialContext)
		{
		}
	}
}
