using System.IO;
using System.Text;

namespace MyAnimeListSharp.Util
{
	/// <summary>
	/// MyAnimeList.net Anime/MangaValues XML requires UTF-8 encoding in the declaration.
	/// But StringWriter "advertises itself using UTF-16" <see cref="http://stackoverflow.com/a/5248439/4035"/>.
	/// So to return UTF-8 in the declaration, we need to overwrite encoding of string writer
	/// </summary>
	/// <remarks>http://myanimelist.net/modules.php?go=api#animevalues</remarks>
	internal class Utf8StringWriter : StringWriter
	{
		public override Encoding Encoding => Encoding.UTF8;

		public Utf8StringWriter(StringBuilder sb)
			: base(sb)
		{
		}
	}
}