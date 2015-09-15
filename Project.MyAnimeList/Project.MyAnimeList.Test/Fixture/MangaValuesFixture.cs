using System;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;
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
				Chapter = 9,
				Volume = 8,
				MangaStatus = MangaStatus.OnHold,
				Score = Score.VeryGood,
				DownloadedChapters = 6,
				TimesReread = 5,
				RereadValue = 4,
				DateStart = new DateTime(2015, 2 ,28),
				DateFinish = new DateTime(2015, 4, 17),
				Priority = Priority.High,
				EnableDiscussion = EnableDiscussion.Enable,
				EnableRereading = EnableRereading.Enable,
				Comments = "This is a manga comment",
				ScanGroup = "Yanime",
				Tags = "Tag1, Tag2, Tag3",
				RetailVolumes = 3
			};
		}
	}
}
