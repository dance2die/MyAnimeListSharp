using Xunit;

namespace Project.MyAnimeList.Test
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