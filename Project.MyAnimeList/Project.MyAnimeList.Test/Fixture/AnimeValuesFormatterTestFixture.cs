using MyAnimeListSharp.Util;

namespace Project.MyAnimeList.Test.Fixture
{
	public class AnimeValuesFormatterTestFixture
	{
		public AnimeValuesFormatter ValuesFormatter { get; set; }

		public AnimeValuesFormatterTestFixture()
		{
			ValuesFormatter = new AnimeValuesFormatter();
		}
	}

	//public class MangaValuesFormatterTestFixture
	//{
	//	public MangaValuesFormatter Formatter { get; set; }

	//	public MangaValuesFormatterTestFixture()
	//	{
	//		Formatter = new MangaValuesFormatter();
	//	}
	//}
}