using MyAnimeListSharp.Facade;
using Xunit;

namespace Project.MyAnimeList.Test.Fixture
{
	public class AnimeListMethodsFixture : IClassFixture<CredentialContextFixture>
	{
		public AnimeListMethods AnimeListMethods { get; set; }

		public AnimeListMethodsFixture()
			: this(new CredentialContextFixture())
		{
		}

		public AnimeListMethodsFixture(CredentialContextFixture credentialContextFixture)
		{
			AnimeListMethods = new AnimeListMethods(credentialContextFixture.CredentialContext);
		}
	}
}
