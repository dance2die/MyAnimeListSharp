using System.Net;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
    public class AccountMethodsTest : CredentialCollectionTest
    {
        private readonly ITestOutputHelper _output;

        public AccountMethodsTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
            : base(credentialContextFixture)
        {
            _output = output;
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

            var credentials = sut.VerifyCredentials();
            _output.WriteLine(credentials);

            Assert.False(string.IsNullOrEmpty(credentials));
            Assert.Contains("id", credentials);
            Assert.Contains("username", credentials);
        }

        [Theory]
        [InlineData("badUserName", "badPassword")]
        [InlineData("aaaaaaaaaa", "bbbbbbbbbb")]
        public void InvalidCredentialsIsReturnedWhenInvalidCredentialIsPassed(string userName, string password)
        {
            ICredentialContext credentialContext = new CredentialContext
            {
                UserName = userName,
                Password = password
            };
            var sut = new AccountMethods(credentialContext);

            string actual = sut.VerifyCredentials();
            _output.WriteLine(actual);

            const string expected = "Invalid credentials";
            Assert.True(expected == actual);
        }
    }
}