using System;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;
using MyAnimeListSharp.Facade;

namespace Project.MyAnimeList.Test.Fixture
{
	public class AnimeValuesFixture
	{
		public AnimeValues Values { get; set; }

		public AnimeValuesFixture()
		{
			Values = GetTestAnimeValues();
		}

		private AnimeValues GetTestAnimeValues()
		{
			return new AnimeValues
			{
				Episode = 1,
				AnimeStatus = AnimeStatus.Completed,
				Score = Score.Bad,
				DownloadedEpisodes = 4,
				StorageType = 5,
				StorageValue = 6,
				TimesRewatched = 7,
				RewatchValue = 8,
				DateStart = new DateTime(2015, 1, 30),
				DateFinish = new DateTime(2015, 7, 31),
				Priority = Priority.Medium,
				EnableDiscussion = EnableDiscussion.Enable,
				EnableRewatching = EnableRewatching.Enable,
				Comments = "This is a comment",
				FansubGroup = "Horrible Subs",
				Tags = "Test Tag1, Test Tag2"
			};
		}

	}
}