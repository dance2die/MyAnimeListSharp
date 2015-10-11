using MyAnimeListSharp.Facade.Async;
using Project.MyAnimeList.Test.Tests;

namespace Project.MyAnimeList.Test.Fixture
{
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
}