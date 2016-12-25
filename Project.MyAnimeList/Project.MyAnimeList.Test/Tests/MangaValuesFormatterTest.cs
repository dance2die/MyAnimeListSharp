using MyAnimeListSharp.Core;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public class MangaValuesFormatterTest : ValuesFormatterTest, IClassFixture<MangaValuesFixture>
	{
		private readonly MangaValuesFormatterTestFixture _formatterFixture;
		private readonly MangaValuesFixture _mangaValuesFixture;

		private const string XML_DECLARATION = @"<?xml version=""1.0"" encoding=""utf-8""?>";

		private readonly string _mangaData =
			XML_DECLARATION +
@"
<entry>
	<chapter>9</chapter>
	<volume>8</volume>
	<status>3</status>
	<score>7</score>
	<times_reread>5</times_reread>
	<reread_value>4</reread_value>
	<date_start>02282015</date_start>
	<date_finish>04172015</date_finish>
	<priority>2</priority>
	<enable_discussion>1</enable_discussion>
	<enable_rereading>1</enable_rereading>
	<comments>This is a manga comment</comments>
	<scan_group>Yanime</scan_group>
	<tags>Tag1, Tag2, Tag3</tags>
	<retail_volumes>3</retail_volumes>
</entry>";


		public MangaValuesFormatterTest(
			MangaValuesFormatterTestFixture formatterFixture,
			MangaValuesFixture mangaValuesFixture)
		{
			_formatterFixture = formatterFixture;
			_mangaValuesFixture = mangaValuesFixture;
		}

		[Fact]
		public void MangaDataShouldMatchFormattedMangaValuesObjectString()
		{
			MangaValues values = _mangaValuesFixture.Values;
			string xmlString = _formatterFixture.Formatter.Format(values);

			var thatXmlAreIdentical = XmlFilesAreIdentical(_mangaData, xmlString);
			Assert.True(thatXmlAreIdentical);
		}
	}
}