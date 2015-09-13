using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Formatters;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class ValuesFormatterFactoryTest
	{
		[Fact]
		public void ValuesFormatterFactoryReturnsAnimeValuesFormatter()
		{
			var sut = new ValuesFormatterFactory();

			var animeValues = new AnimeValues();
			var valuesFormatter = sut.Create(animeValues);

			Assert.IsType<AnimeValuesFormatter>(valuesFormatter);
		}

		[Fact]
		public void ValuesFormatterFactoryReturnsMangaValuesFormatter()
		{
			var sut = new ValuesFormatterFactory();

			var mangaValues = new MangaValues();
			var valuesFormatter = sut.Create(mangaValues);

			Assert.IsType<MangaValuesFormatter>(valuesFormatter);

		}
	}
}
