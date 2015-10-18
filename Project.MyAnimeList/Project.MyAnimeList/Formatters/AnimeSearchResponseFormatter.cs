using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	public class AnimeSearchResponseFormatter : IFormatter<AnimeSearchResponse>
	{
		public IFormatter<AnimeSearchResponse> Strategy { get; set; }

		public AnimeSearchResponseFormatter(IFormatter<AnimeSearchResponse> strategy)
		{
			Strategy = strategy;
		}

		public string Format(AnimeSearchResponse value)
		{
			return Strategy.Format(value);
		}
	}
}