using MyAnimeListSharp.Facade;
using Xunit;

namespace Project.MyAnimeList.Test
{
	public class AccountMethodsTest : CredentialCollectionTest
	{
		public AccountMethodsTest(CredentialContextFixture credentialContextFixture) 
			: base(credentialContextFixture)
		{
		}

		[Fact]
		public void TestCredentialContextNotEmpty()
		{
			var sut = CredentialContextFixture.CredentialContext;

			Assert.False(string.IsNullOrEmpty(sut.UserName));
			Assert.False(string.IsNullOrEmpty(sut.Password));
		}

		[Fact]
		public void TestVerifiyCredentialsNotEmpty()
		{
			var sut = new AccountMethods(CredentialContextFixture.CredentialContext);

			Assert.False(string.IsNullOrEmpty(sut.VerifyCredentials()));
		}
	}
}
