using System;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;

namespace Project.MyAnimeList.Test.Fixture
{
	public class AnimeValuesFixture
	{
		public AnimeValues Values { get; set; }

		/// <summary>
		/// Gate: Jieitai Kanochi nite, Kaku Tatakaeri
		/// http://myanimelist.net/anime/28907/Gate:_Jieitai_Kanochi_nite_Kaku_Tatakaeri
		/// </summary>
		public static int AnimeId { get; set; } = 28907;

		public static string XmlDeclaration { get; set; } = @"<?xml version=""1.0"" encoding=""UTF-8""?>";

		public static readonly string Data = 
			XmlDeclaration +
			@"
				<entry>
					<episode>1</episode>
					<status>2</status>
					<score>3</score>
					<downloaded_episodes>4</downloaded_episodes>
					<storage_type>5</storage_type>
					<storage_value>6</storage_value>
					<times_rewatched>7</times_rewatched>
					<rewatch_value>8</rewatch_value>
					<date_start>01302015</date_start>
					<date_finish>07312015</date_finish>
					<priority>1</priority>
					<enable_discussion>1</enable_discussion>
					<enable_rewatching>1</enable_rewatching>
					<comments>This is a comment</comments>
					<fansub_group>Horrible Subs</fansub_group>
					<tags>Test Tag1, Test Tag2</tags>
				</entry>";


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