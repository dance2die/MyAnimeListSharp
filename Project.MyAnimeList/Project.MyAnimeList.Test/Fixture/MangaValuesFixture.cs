using System;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;

namespace Project.MyAnimeList.Test.Fixture
{
	public class MangaValuesFixture
	{
		public MangaValues Values { get; set; }

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/manga/67879/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		public const int ID = 67879;

		public static readonly string Data =
			@"<?xml version = ""1.0"" encoding=""UTF-8"" ?>
			<entry>
				<chapter>40</chapter>
				<volume>1</volume>
				<status>1</status>
				<score>9</score>
				<times_reread></times_reread>
				<reread_value></reread_value>
				<date_start></date_start>
				<date_finish></date_finish>
				<priority></priority>
				<enable_discussion></enable_discussion>
				<enable_rereading></enable_rereading>
				<comments></comments>
				<scan_group></scan_group>
				<tags></tags>
				<retail_volumes></retail_volumes>
			</entry>";

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
