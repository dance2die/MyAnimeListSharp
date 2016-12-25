using Xunit;

namespace Project.MyAnimeList.Test.Fixture
{
    /// <remarks>
    /// http://xunit.github.io/docs/shared-context.html
    /// </remarks>
    [CollectionDefinition("Credential collection")]
    public class CredentialContextCollection : ICollectionFixture<CredentialContextFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}