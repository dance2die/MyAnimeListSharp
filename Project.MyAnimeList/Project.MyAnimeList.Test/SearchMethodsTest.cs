using Project.MyAnimeList.Facade;
using Xunit;

namespace Project.MyAnimeList.Test
{
	public class SearchMethodsTest : CredentialCollectionTest
	{
		public SearchMethods SearchMethods { get; private set; }

		public SearchMethodsTest(CredentialContextFixture credentialContextFixture)
			: base(credentialContextFixture)
		{
			SearchMethods = new SearchMethods(credentialContextFixture.CredentialContext);
		}
	}
}
