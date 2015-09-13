using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.ContentBuilders
{
	public class AnimeValuesContentBuilder : ValuesContentBuilder<AnimeValues>
	{
		/// <summary>
		/// Build XML content according to MyAnimeList.net specification
		/// </summary>
		/// <remarks>
		/// http://myanimelist.net/modules.php?go=api#animevalues
		/// </remarks>
		public override XElement BuildContent(AnimeValues values)
		{
			XElement result = new XElement(
				new XElement("entry",
					new XElement("episode", values.Episode),
					new XElement("status", GetUnderlyingEnumValue(values.AnimeStatus)),
					new XElement("score", GetUnderlyingEnumValue(values.Score)),
					new XElement("downloaded_episodes", values.DownloadedEpisodes),
					new XElement("storage_type", values.StorageType),
					new XElement("storage_value", values.StorageValue),
					new XElement("times_rewatched", values.TimesRewatched),
					new XElement("rewatch_value", values.RewatchValue),
					new XElement("date_start", _dateTimeFormatter.Format(values.DateStart)),
					new XElement("date_finish", _dateTimeFormatter.Format(values.DateFinish)),
					new XElement("priority", GetUnderlyingEnumValue(values.Priority)),
					new XElement("enable_discussion", GetUnderlyingEnumValue(values.EnableDiscussion)),
					new XElement("enable_rewatching", GetUnderlyingEnumValue(values.EnableRewatching)),
					new XElement("comments", values.Comments),
					new XElement("fansub_group", values.FansubGroup),
					new XElement("tags", values.Tags)
					)
				);

			return result;
		}
	}
}