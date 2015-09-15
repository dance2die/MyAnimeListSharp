using System;
using System.Xml.Linq;
using MyAnimeListSharp;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Enums;
using MyAnimeListSharp.Facade;
using Xunit;
using Project.MyAnimeList.Test.Fixture;
using Xunit.Abstractions;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeValuesTest : CredentialCollectionTest
	{
		private const string XML_DECLARATION = @"<?xml version=""1.0"" encoding=""UTF-8""?>";

		private readonly ITestOutputHelper _output;
		private readonly AnimeValues _sut;

		public AnimeValuesTest(CredentialContextFixture credentialContextFixture, ITestOutputHelper output)
			: base(credentialContextFixture)
		{
			_output = output;
			_sut = new AnimeValues();
		}

		[Fact]
		public void TestXmlDeclration()
		{
			string standalone = null;
			var doc = new XDocument(new XDeclaration("1.0", "UTF-8", standalone));

			var declaration = doc.Declaration.ToString();
			_output.WriteLine(XML_DECLARATION);
			_output.WriteLine(declaration);
			Assert.True(string.Compare(XML_DECLARATION, declaration, StringComparison.InvariantCultureIgnoreCase) == 0);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		[InlineData(-100)]
		public void TestEpisodeValueIsNotNegative(short episode)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Episode = episode);
		}

		[Theory]
		[InlineData(AnimeStatus.Watching)]
		[InlineData(AnimeStatus.Completed)]
		[InlineData(AnimeStatus.OnHold)]
		[InlineData(AnimeStatus.Dropped)]
		[InlineData(AnimeStatus.PlanToWatch)]
		public void TestStatus(AnimeStatus value)
		{
			_sut.AnimeStatus = value;

			Assert.Equal(value, _sut.AnimeStatus);
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
		[InlineData(-100)]
		public void TestIfDownloadedEpisodesIsNegativeArgumentOutOfRangeExceptionIsThrown(int downloadedEpisodes)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.DownloadedEpisodes = downloadedEpisodes);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(1)]
		[InlineData(655)]
		public void TestDownloadedEpisodesValueAssignment(int value)
		{
			_sut.DownloadedEpisodes = value;

			Assert.Equal(value, _sut.DownloadedEpisodes);
		}

		/// <remarks>
		/// There isn't enough documentation for this.
		/// And also since AddAnime functionality is not implemented on the server, 
		/// I can't even figure ou what the range of allowed values are.
		/// </remarks>
		[Fact]
		public void TestStorageType()
		{
			_sut.StorageType = 1;

			Assert.Equal(1, _sut.StorageType);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestNegativeStorageValueThrowsArgumentOutOfRangeException(float value)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.StorageValue = value);
		}

		[Fact]
		public void TestStorageValue()
		{
			const float storageValue = 0.01F;
			_sut.StorageValue = storageValue;

			Assert.Equal(storageValue, _sut.StorageValue);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestNegativeTimesRewatchedThrowsArgumentOutOfRangeException(int value)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.TimesRewatched = value);
		}

		[Theory]
		[InlineData(-1)]
		[InlineData(-10)]
		public void TestNegativeRewatchValueThrowsArgumentOutOfRangeExceptoin(int value)
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.RewatchValue = value);
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
		[InlineData(Priority.Low)]
		[InlineData(Priority.Medium)]
		[InlineData(Priority.High)]
		[InlineData(Priority.Undefined)]
		public void TestPriority(Priority expected)
		{
			_sut.Priority = expected;

			Assert.Equal(expected, _sut.Priority);
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
		[InlineData(EnableRewatching.Disable)]
		[InlineData(EnableRewatching.Enable)]
		public void TestEnableRewatching(EnableRewatching value)
		{
			_sut.EnableRewatching = value;

			Assert.Equal(value, _sut.EnableRewatching);
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
		[InlineData("HorribleSubs")]
		[InlineData("GG Fansubs")]
		[InlineData("UTW Fansubs")]
		public void TestFansubGroup(string value)
		{
			_sut.FansubGroup = value;

			Assert.Equal(value, _sut.FansubGroup);
		}

		[Theory]
		[InlineData("tag1, tag2")]
		[InlineData("Adapted to Anime, Adapted to Movie")]
		public void TestTags(string value)
		{
			_sut.Tags = value;

			Assert.Equal(value, _sut.Tags);
		}
	}
}
