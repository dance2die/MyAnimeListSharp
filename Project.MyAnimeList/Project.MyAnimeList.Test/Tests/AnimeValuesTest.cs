using System;
using System.Xml.Linq;
using MyAnimeListSharp;
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

		private readonly string _data =
				XML_DECLARATION +
			@"<entry>
					<episode>9</episode>
					<status>1</status>
					<score>9</score>
					<downloaded_episodes></downloaded_episodes>
					<storage_type></storage_type>
					<storage_value></storage_value>
					<times_rewatched></times_rewatched>
					<rewatch_value></rewatch_value>
					<date_start></date_start>
					<date_finish></date_finish>
					<priority></priority>
					<enable_discussion></enable_discussion>
					<enable_rewatching></enable_rewatching>
					<comments></comments>
					<fansub_group></fansub_group>
					<tags>test tag, 2nd tag</tags>
				</ entry>";

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
			Assert.Throws<ArgumentOutOfRangeException>(() => _sut.Episode = -1);
		}

		[Theory]
		[InlineData(StatusEnum.Watching)]
		[InlineData(StatusEnum.Completed)]
		[InlineData(StatusEnum.OnHold)]
		[InlineData(StatusEnum.Dropped)]
		[InlineData(StatusEnum.PlanToWatch)]
		public void TestStatus(StatusEnum value)
		{
			_sut.Status = value;

			Assert.Equal(value, _sut.Status);
		}

		[Theory]
		[InlineData(ScoreEnum.Appalling)]
		[InlineData(ScoreEnum.Horrible)]
		[InlineData(ScoreEnum.VeryBad)]
		[InlineData(ScoreEnum.Bad)]
		[InlineData(ScoreEnum.Average)]
		[InlineData(ScoreEnum.Fine)]
		[InlineData(ScoreEnum.Good)]
		[InlineData(ScoreEnum.VeryBad)]
		[InlineData(ScoreEnum.Great)]
		[InlineData(ScoreEnum.MasterPiece)]
		public void TestScore(ScoreEnum value)
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
	}
}
