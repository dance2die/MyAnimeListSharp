using System.IO;
using System.Xml;
using Microsoft.XmlDiffPatch;
using Project.MyAnimeList.Test.Fixture;
using Xunit;

namespace Project.MyAnimeList.Test.Tests
{
	public abstract class ValuesFormatterTest :
		IClassFixture<AnimeValuesFormatterTestFixture>,
		IClassFixture<MangaValuesFormatterTestFixture>
	{
		/// <summary>
		/// Compares two XML files to see if they are the same.
		/// </summary>
		/// <returns>
		/// Returns true if two XML files are functionally identical, ignoring comments, white space, and child order.
		/// </returns>
		/// <remarks>http://stackoverflow.com/a/19954063/4035</remarks>
		protected static bool XmlFilesAreIdentical(string file1, string file2)
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