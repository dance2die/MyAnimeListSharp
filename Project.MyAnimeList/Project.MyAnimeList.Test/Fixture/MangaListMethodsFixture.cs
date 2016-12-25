using MyAnimeListSharp.Facade;
using Xunit;

namespace Project.MyAnimeList.Test.Fixture
{
    public class MangaListMethodsFixture : IClassFixture<CredentialContextFixture>
    {
        public MangaListMethods MangaListMethods { get; set; }

        public MangaListMethodsFixture()
            : this(new CredentialContextFixture())
        {
        }

        public MangaListMethodsFixture(CredentialContextFixture credentialContextFixture)
        {
            MangaListMethods = new MangaListMethods(credentialContextFixture.CredentialContext);
        }
    }
}