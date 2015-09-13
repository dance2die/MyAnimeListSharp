using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.ContentBuilders
{
	public class MangaValuesContentBuilder : ValuesContentBuilder<MangaValues>
	{
		/// <summary>
		/// Build XML content according to MyAnimeList.net specification
		/// </summary>
		/// <remarks>
		/// http://myanimelist.net/modules.php?go=api#animevalues
		/// </remarks>
		public override XElement BuildContent(MangaValues values)
		{
			XElement result = new XElement(
				new XElement("entry",
					new XElement("chapter", values.Chapter),
					new XElement("volume", values.Volume),
					new XElement("status", GetUnderlyingEnumValue(values.MangaStatus)),
					new XElement("score", GetUnderlyingEnumValue(values.Score)),
					new XElement("downloaded_chapters", values.DownloadedChapters),
					new XElement("times_reread", values.TimesReread),
					new XElement("reread_value", values.RereadValue),
					new XElement("date_start", _dateTimeFormatter.Format(values.DateStart)),
					new XElement("date_finish", _dateTimeFormatter.Format(values.DateFinish)),
					new XElement("priority", GetUnderlyingEnumValue(values.Priority)),
					new XElement("enable_discussion", GetUnderlyingEnumValue(values.EnableDiscussion)),
					new XElement("enable_rereading", GetUnderlyingEnumValue(values.EnableRereading)),
					new XElement("comments", values.Comments),
					new XElement("scan_group", values.ScanGroup),
					new XElement("tags", values.Tags),
					new XElement("retail_volumes", values.RetailVolumes)
					)
				);

			return result;
		}
	}
}