using MyAnimeListSharp.Facade;
using Xunit;

namespace Project.MyAnimeList.Test.Fixture
{
    public class SearchMethodsFixture : IClassFixture<CredentialContextFixture>
    {
        public SearchMethods SearchMethods { get; set; }

        public SearchMethodsFixture()
            : this(new CredentialContextFixture())
        {
        }

        public SearchMethodsFixture(CredentialContextFixture credentialContextFixture)
        {
            SearchMethods = new SearchMethods(credentialContextFixture.CredentialContext);
        }
    }
}