using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Util
{
	[Serializable, XmlRoot("manga")]
	public class MangaSearchResponse
	{
		[XmlElement("entry")]
		public List<MangaEntry> Entries { get; set; } = new List<MangaEntry>();
	}
}