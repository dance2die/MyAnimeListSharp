using MyAnimeListSharp.Facade;
using MyAnimeListSharp.Formatters;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class ValuesFormatterFactoryTest : IClassFixture<ValuesFormatterFactoryFixture>
	{
		public ValuesFormatterFactoryFixture Fixture { get; set; }

		public ValuesFormatterFactoryTest(ValuesFormatterFactoryFixture fixture)
		{
			Fixture = fixture;
		}

		[Fact]
		public void ValuesFormatterFactoryReturnsAnimeValuesFormatter()
		{
			var sut = Fixture.Factory;

			var animeValues = new AnimeValues();
			var valuesFormatter = sut.Create(animeValues);

			Assert.IsType<AnimeValuesFormatter>(valuesFormatter);
		}

		[Fact]
		public void ValuesFormatterFactoryReturnsMangaValuesFormatter()
		{
			var sut = Fixture.Factory;

			var mangaValues = new MangaValues();
			var valuesFormatter = sut.Create(mangaValues);

			Assert.IsType<MangaValuesFormatter>(valuesFormatter);

		}
	}
}
