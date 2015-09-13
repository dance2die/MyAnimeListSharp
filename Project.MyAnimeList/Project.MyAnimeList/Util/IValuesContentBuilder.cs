using System;
using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.Util
{
	public interface IValuesContentBuilder<in T> where T : MyAnimeListValues
	{
		XElement BuildContent(T values);
	}

	public abstract class ValuesContentBuilder<T> : IValuesContentBuilder<T> where T : MyAnimeListValues
	{
		protected readonly IDateTimeFormatter _dateTimeFormatter;

		protected ValuesContentBuilder()
			: this(new DefaultDateTimeFormatter())
		{
		}

		public abstract XElement BuildContent(T values);

		protected ValuesContentBuilder(IDateTimeFormatter dateTimeFormatter)
		{
			_dateTimeFormatter = dateTimeFormatter;
		}

		protected int GetUnderlyingEnumValue<TIn>(TIn enumValue) where TIn : struct
		{
			if (!typeof(TIn).IsEnum)
				throw new ArgumentException("Argument is not an enumeration", nameof(enumValue));

			return (int)(object)enumValue;
		}
	}

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
					new XElement("status", values.MangaStatus),
					new XElement("score", values.Score),
					new XElement("downloaded_chapters", values.DownloadedChapters),
					new XElement("times_reread", values.TimesReread),
					new XElement("reread_value", values.RereadValue),
					new XElement("date_start", values.DateStart),
					new XElement("date_finish", values.DateFinish),
					new XElement("priority", values.Priority),
					new XElement("enable_discussion", values.EnableDiscussion),
					new XElement("enable_rereading", values.EnableRereading),
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