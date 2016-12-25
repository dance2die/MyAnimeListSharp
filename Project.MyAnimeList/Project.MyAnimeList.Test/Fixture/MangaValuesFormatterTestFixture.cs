using MyAnimeListSharp.Formatters;
using MyAnimeListSharp.Util;

namespace Project.MyAnimeList.Test.Fixture
{
    public class MangaValuesFormatterTestFixture
    {
        public MangaValuesFormatter Formatter { get; set; }

        public MangaValuesFormatterTestFixture()
        {
            Formatter = new MangaValuesFormatter();
        }
    }
}