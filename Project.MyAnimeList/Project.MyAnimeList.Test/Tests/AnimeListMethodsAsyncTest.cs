using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeListMethodsAsyncTest :
		CredentialCollectionTest, 
		IClassFixture<AnimeValuesFixture>, 
		IClassFixture<AnimeListMethodsAsyncFixture>
	{
		private readonly ITestOutputHelper _output;
		private readonly AnimeValuesFixture _animeValuesFixture;
		private readonly AnimeListMethodsAsyncFixture _animeListMethodsAsyncFixture;

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		private const int ID = 28907;

		public AnimeListMethodsAsyncTest(
			CredentialContextFixture credentialContextFixture,
			ITestOutputHelper output, 
			AnimeValuesFixture animeValuesFixture,
			AnimeListMethodsAsyncFixture animeListMethodsAsyncFixture) 
				: base(credentialContextFixture)
		{
			_output = output;
			_animeValuesFixture = animeValuesFixture;
			_animeListMethodsAsyncFixture = animeListMethodsAsyncFixture;
		}
	}
}
