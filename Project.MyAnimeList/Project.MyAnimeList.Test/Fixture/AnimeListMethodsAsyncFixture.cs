using MyAnimeListSharp.Facade.Async;

namespace Project.MyAnimeList.Test.Fixture
{
    public class AnimeListMethodsAsyncFixture
    {
        public AnimeListMethodsAsync AnimeListMethods { get; set; }

        public AnimeListMethodsAsyncFixture()
            : this(new CredentialContextFixture())
        {
        }

        public AnimeListMethodsAsyncFixture(CredentialContextFixture credentialContextFixture)
        {
            AnimeListMethods = new AnimeListMethodsAsync(credentialContextFixture.CredentialContext);
        }
    }
}