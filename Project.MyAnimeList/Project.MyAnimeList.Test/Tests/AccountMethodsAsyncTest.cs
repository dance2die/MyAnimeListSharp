using Project.MyAnimeList.Test.Fixture;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class AccountMethodsAsyncTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;

		public AccountMethodsAsyncTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
			: base(credentialContextFixture)
		{
			_output = output;
		}
	}
}
