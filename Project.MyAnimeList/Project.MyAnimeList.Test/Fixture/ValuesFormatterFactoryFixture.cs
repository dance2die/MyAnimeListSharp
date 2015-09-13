using MyAnimeListSharp.Formatters;

namespace Project.MyAnimeList.Test.Fixture
{
	public class ValuesFormatterFactoryFixture
	{
		public ValuesFormatterFactory Factory { get; set; }

		public ValuesFormatterFactoryFixture()
		{
			Factory = new ValuesFormatterFactory();
		}
	}
}