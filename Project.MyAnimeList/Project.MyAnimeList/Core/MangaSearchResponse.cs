using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Core
{
	[Serializable, XmlRoot("manga")]
	public class MangaSearchResponse : ISearchResponse<MangaEntry>
	{
		[XmlElement("entry")]
		public List<MangaEntry> Entries { get; set; } = new List<MangaEntry>();
	}
}