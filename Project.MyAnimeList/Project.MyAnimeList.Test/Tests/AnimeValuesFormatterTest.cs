using System.IO;
using System.Xml;
using Microsoft.XmlDiffPatch;
using MyAnimeListSharp.Facade;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class AnimeValuesFormatterTest : IClassFixture<AnimeValuesFormatterTestFixture>, IClassFixture<AnimeValuesFixture>
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

		//private readonly string _mangaData =
		//	@"<?xml version = ""1.0"" encoding=""UTF-8"" ?>
		//	<entry>
		//		<chapter>9</chapter>
		//		<volume>8</volume>
		//		<status>3</status>
		//		<score>7</score>
		//		<downloaded_chapters>6</downloaded_chapters>
		//		<times_reread>5</times_reread>
		//		<reread_value>4</reread_value>
		//		<date_start>02282015</date_start>
		//		<date_finish>04172015</date_finish>
		//		<priority>3</priority>
		//		<enable_discussion>1</enable_discussion>
		//		<enable_rereading>1</enable_rereading>
		//		<comments>This is a manga comment</comments>
		//		<scan_group>Yanime</scan_group>
		//		<tags>Tag1, Tag2, Tag3</tags>
		//		<retail_volumes>3</retail_volumes>
		//	</entry>";


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
			string xmlString = _formatterFixture.Formatter.Format(values);

			var thatXmlAreIdentical = XmlFilesAreIdentical(_animeData, xmlString);
			Assert.True(thatXmlAreIdentical);
		}

		//[Fact]
		//public void MangaDataShouldMatchFormattedMangaValuesObjectString()
		//{
		//	MangaValues values = _mangaValuesFixture.Values;
		//	string xmlString = _formatterFixture.Formatter.Format(values);

		//	var thatXmlAreIdentical = XmlFilesAreIdentical(_mangaData, xmlString);
		//	Assert.True(thatXmlAreIdentical);
		//}


		/// <summary>
		/// Compares two XML files to see if they are the same.
		/// </summary>
		/// <returns>
		/// Returns true if two XML files are functionally identical, ignoring comments, white space, and child order.
		/// </returns>
		/// <remarks>http://stackoverflow.com/a/19954063/4035</remarks>
		private static bool XmlFilesAreIdentical(string file1, string file2)
		{
			var xmldiff = new XmlDiff();
			var r1 = XmlReader.Create(new StringReader(file1));
			var r2 = XmlReader.Create(new StringReader(file2));
			var sw = new StringWriter();
			var xw = new XmlTextWriter(sw) { Formatting = Formatting.Indented };

			xmldiff.Options = XmlDiffOptions.IgnorePI |
				XmlDiffOptions.IgnoreChildOrder |
				XmlDiffOptions.IgnoreComments |
				XmlDiffOptions.IgnoreWhitespace;
			bool areIdentical = xmldiff.Compare(r1, r2, xw);

			string differences = sw.ToString();

			return areIdentical;
		}
	}
}
