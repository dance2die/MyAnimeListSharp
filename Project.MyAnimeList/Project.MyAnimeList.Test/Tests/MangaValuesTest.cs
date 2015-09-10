using System;
using MyAnimeListSharp.Enums;
using MyAnimeListSharp.Facade;
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

		private readonly string _data =
				XML_DECLARATION +
			@"<entry>
				<volume>6</volume>
				<volume>1</volume>
				<status>1</status>
				<score>8</score>
				<downloaded_chapters></downloaded_chapters>
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

	}
}
