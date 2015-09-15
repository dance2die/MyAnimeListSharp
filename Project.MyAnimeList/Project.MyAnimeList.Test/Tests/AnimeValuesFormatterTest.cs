﻿using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeValuesFormatterTest : ValuesFormatterTest, IClassFixture<AnimeValuesFixture>
	{
		private readonly AnimeValuesFormatterTestFixture _formatterFixture;
		private readonly AnimeValuesFixture _animeValuesFixture;

		private const string XML_DECLARATION = @"<?xml version=""1.0"" encoding=""utf-8""?>";

		private static readonly string _animeData =
			XML_DECLARATION +
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

		public AnimeValuesFormatterTest(
			AnimeValuesFormatterTestFixture formatterFixture, 
			AnimeValuesFixture animeValuesFixture)
		{
			_formatterFixture = formatterFixture;
			_animeValuesFixture = animeValuesFixture;
		}

		[Fact]
		public void AnimeDataShouldMatchFormattedAnimeValuesObjectString()
		{
			AnimeValues values = _animeValuesFixture.Values;
			string xmlString = _formatterFixture.ValuesFormatter.Format(values);

			var thatXmlAreIdentical = XmlFilesAreIdentical(_animeData, xmlString);
			Assert.True(thatXmlAreIdentical);
		}
	}
}
