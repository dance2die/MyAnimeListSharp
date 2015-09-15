using System;
using System.Globalization;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Util
{
	public class AnimeEntry
	{
		[XmlElement(ElementName = "id")]
		public int Id { get; set; }

		[XmlElement(ElementName = "title")]
		public string Title { get; set; }

		[XmlElement(ElementName = "english")]
		public string English { get; set; }

		[XmlElement(ElementName = "synonyms")]
		public string Synonyms { get; set; }

		[XmlElement(ElementName = "episodes")]
		public int Episodes { get; set; }

		[XmlElement(ElementName = "score")]
		public double Score { get; set; }

		[XmlElement(ElementName = "type")]
		public string Type { get; set; }

		[XmlElement(ElementName = "status")]
		public string Status { get; set; }

		[XmlElement(ElementName = "start_date")]
		public string StartDate { get; set; }

		[XmlElement(ElementName = "end_date")]
		public string EndDate { get; set; }

		//private bool IsDate(DateTime? value)
		//{
		//	if (value == null) return false;

		//	DateTime outValue;
		//	return DateTime.TryParse(value.Value.ToString(CultureInfo.InvariantCulture), out outValue);
		//}

		[XmlElement(ElementName = "synopsis")]
		public string Synopsis { get; set; }

		[XmlElement(ElementName = "image")]
		public string Image { get; set; }

	}
}