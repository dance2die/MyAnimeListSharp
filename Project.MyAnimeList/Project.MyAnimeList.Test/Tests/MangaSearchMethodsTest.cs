using Project.MyAnimeList.Test.Fixture;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaSearchMethodsTest : CredentialCollectionTest
	{
		private readonly ITestOutputHelper _output;

		public MangaSearchMethodsTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output) 
			: base(credentialContextFixture)
		{
			_output = output;
		}
	}
}
