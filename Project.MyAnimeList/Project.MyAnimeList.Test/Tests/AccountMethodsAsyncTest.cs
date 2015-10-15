using System.Net;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Facade.Async;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
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

		[Fact]
		public async void TestVerifiyCredentialsNotEmpty()
		{
			var sut = new AccountMethodsAsync(CredentialContextFixture.CredentialContext);

			string credentials = await sut.VerifyCredentialsAsync();
			_output.WriteLine(credentials);

			Assert.False(string.IsNullOrWhiteSpace(credentials));
			Assert.Contains("id", credentials);
			Assert.Contains("username", credentials);
		}

		[Theory]
		[InlineData("badUserName", "badPassword")]
		[InlineData("aaaaaaaaaa", "bbbbbbbbbb")]
		public async void ThrowsExceptionWhenInvalidCredentialIsPassed(string userName, string password)
		{
			ICredentialContext credentialContext = new CredentialContext
			{
				UserName = userName,
				Password = password
			};
			var sut = new AccountMethodsAsync(credentialContext);

			await Assert.ThrowsAsync<WebException>(async () =>
			{
				string credentials = await sut.VerifyCredentialsAsync();
				_output.WriteLine(credentials);
			});
		}
	}
}
