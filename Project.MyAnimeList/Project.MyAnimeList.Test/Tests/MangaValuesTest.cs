using System;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;
using Project.MyAnimeList.Test.Fixture;
using Xunit;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaValuesTest : CredentialCollectionTest
	{
		private const string XML_DECLARATION = @"<?xml version=""1.0"" encoding=""UTF-8""?>";

		private readonly ITestOutputHelper _output;
		private readonly MangaValues _sut;

		public MangaValuesTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
			: base(credentialContextFixture)
		{
			_output = output;
			_sut = new MangaValues();
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestChapterValueIsNotNegative(int chapter)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Chapter = chapter);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestVolumeValueIsNotNegative(int volume)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Volume = volume);
		}

		[Theory]
		[InlineData(MangaStatus.Reading)]
		[InlineData(MangaStatus.Completed)]
		[InlineData(MangaStatus.OnHold)]
		[InlineData(MangaStatus.Dropped)]
		[InlineData(MangaStatus.PlanToRead)]
		public void TestMangaStatus(MangaStatus mangaStatus)
		{
			_sut.MangaStatus = mangaStatus;

			Assert.Equal(mangaStatus, _sut.MangaStatus);
		}

		[Theory]
		[InlineData(Score.Appalling)]
		[InlineData(Score.Horrible)]
		[InlineData(Score.VeryBad)]
		[InlineData(Score.Bad)]
		[InlineData(Score.Average)]
		[InlineData(Score.Fine)]
		[InlineData(Score.Good)]
		[InlineData(Score.VeryBad)]
		[InlineData(Score.Great)]
		[InlineData(Score.MasterPiece)]
		public void TestScore(Score value)
		{
			_sut.Score = value;

			Assert.Equal(value, _sut.Score);
		}

		/// <remarks>
		/// On MyAnimeList.net, adding a negative value for Downloaded Episodes sets the value back to 0
		/// </remarks>
		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestIfDownloadedChaptersIsNegativeArgumentOutOfRangeExceptionIsThrown(int downloadedChapters)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.DownloadedChapters = downloadedChapters);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestIfRereadCountIsNegativeArgumentOutOfRangeExceptionIsThrown(int timesReread)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.TimesReread = timesReread);
		}

		[Theory]
		[InlineData(256)]
		[InlineData(9999)]
		public void TestIfRereadCountIsOver255ArgumentOutOfRangeExceptionIsThrown(int timesReread)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.TimesReread = timesReread);
		}

		[Fact]
		public void TestDateStart()
		{
			DateTime dateStart = DateTime.Now;
			_sut.DateStart = dateStart;

			Assert.Equal(dateStart, _sut.DateStart);
		}

		[Fact]
		public void TestDateFinish()
		{
			DateTime dateFinish = DateTime.Now;
			_sut.DateFinish = dateFinish;

			Assert.Equal(dateFinish, _sut.DateFinish);
		}

		[Theory]
		[InlineData(Priority.Undefined)]
		[InlineData(Priority.Low)]
		[InlineData(Priority.Medium)]
		[InlineData(Priority.High)]
		public void TestPriority(Priority priority)
		{
			_sut.Priority = priority;

			Assert.Equal(priority, _sut.Priority);
		}

		[Theory]
		[InlineData(EnableDiscussion.Disable)]
		[InlineData(EnableDiscussion.Enable)]
		public void TestEnableDiscussion(EnableDiscussion value)
		{
			_sut.EnableDiscussion = value;

			Assert.Equal(value, _sut.EnableDiscussion);
		}

		[Theory]
		[InlineData(EnableRereading.Disable)]
		[InlineData(EnableRereading.Enable)]
		public void TestEnableRereading(EnableRereading value)
		{
			_sut.EnableRereading = value;

			Assert.Equal(value, _sut.EnableRereading);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestRereadValueIsNotNegative(int value)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.RereadValue = value);
		}

		[Theory]
		[InlineData("This is a comment")]
		[InlineData("Comment2")]
		public void TestComment(string value)
		{
			_sut.Comments = value;

			Assert.Equal(value, _sut.Comments);
		}

		[Theory]
		[InlineData("Yanime")]
		[InlineData("Sense-Scans")]
		[InlineData("Imperial Scans")]
		public void TestScanGroup(string value)
		{
			_sut.ScanGroup = value;

			Assert.Equal(value, _sut.ScanGroup);
		}

		[Theory]
		[InlineData("tag1, tag2")]
		[InlineData("Adapted to Anime, Adapted to Movie")]
		public void TestTags(string value)
		{
			_sut.Tags = value;

			Assert.Equal(value, _sut.Tags);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestNegativeRetailVolumesThrowException(int retailVolumes)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.RetailVolumes = retailVolumes);
		}
	}
}
