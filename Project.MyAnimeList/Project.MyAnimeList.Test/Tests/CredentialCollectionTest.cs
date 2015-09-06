using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	[Collection("Credential collection")]
	public abstract class CredentialCollectionTest
	{
		public CredentialContextFixture CredentialContextFixture { get; set; }

		protected CredentialCollectionTest(CredentialContextFixture credentialContextFixture)
		{
			CredentialContextFixture = credentialContextFixture;
		}
	}
}