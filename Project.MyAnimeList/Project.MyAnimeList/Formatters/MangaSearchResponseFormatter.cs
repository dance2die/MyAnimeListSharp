using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	public class MangaSearchResponseFormatter
	{
		public IFormatter<MangaSearchResponse> Strategy { get; set; }

		public MangaSearchResponseFormatter(IFormatter<MangaSearchResponse> strategy)
		{
			Strategy = strategy;
		}

		public string Format(MangaSearchResponse value)
		{
			return Strategy.Format(value);
		}
	}
}