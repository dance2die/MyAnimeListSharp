using System;
using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.Util
{
	public class ValuesFormatter : IFormatter<AnimeValues>
	{
		private readonly IDateTimeFormatter _dateTimeFormatter;
		private readonly IXmlFormatter _xmlFormatter;

		/// <remarks>
		/// This is getting out of hand...
		/// Need to learn IoC frameworks like Ninject or Castle Windsor...
		/// </remarks>
		public ValuesFormatter()
			: this(new DefaultDateTimeFormatter(), new DefaultXmlFormatter())
		{
		}

		public ValuesFormatter(IDateTimeFormatter dateTimeFormatter, IXmlFormatter xmlFormatter)
		{
			_dateTimeFormatter = dateTimeFormatter;
			_xmlFormatter = xmlFormatter;
		}

		public string Format(AnimeValues values)
		{
			XDocument document = FormatAnimeValuesToXml(values);
			var xmlString = _xmlFormatter.Format(document);
			return xmlString;
		}

		private XDocument FormatAnimeValuesToXml(AnimeValues values)
		{
			const string standalone = null;
			var declaration = new XDeclaration("1.0", "UTF-8", standalone);
			XElement content = BuildContent(values);

			var document = new XDocument(declaration, content);
			return document;
		}

		/// <summary>
		/// Build XML content according to MyAnimeList.net specification
		/// </summary>
		/// <remarks>
		/// http://myanimelist.net/modules.php?go=api#animevalues
		/// </remarks>
		private XElement BuildContent(AnimeValues values)
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

		private int GetUnderlyingEnumValue<T>(T enumValue) where T : struct
		{
			if (!typeof (T).IsEnum)
				throw new ArgumentException("Argument is not an enumeration", nameof(enumValue));

			return (int)(object)enumValue;
		}
	}
}
