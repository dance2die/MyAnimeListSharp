using MyAnimeListSharp.Facade;

namespace Project.MyAnimeList.Test.Fixture
{
	public class MangaValuesFixture
	{
		public MangaValues Values { get; set; }

		public MangaValuesFixture()
		{
			Values = GetTestMangaValues();
		}

		private MangaValues GetTestMangaValues()
		{
			return new MangaValues
			{
			};
		}
	}
}
