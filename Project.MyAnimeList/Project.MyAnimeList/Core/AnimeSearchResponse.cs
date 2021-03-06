using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MyAnimeListSharp.Core
{
    /// <summary>
    /// Class representing AnimeSearch result
    /// </summary>
    /// <remarks>http://stackoverflow.com/a/608181/4035</remarks>
    [Serializable, XmlRoot("anime")]
    public class AnimeSearchResponse : ISearchResponse<AnimeEntry>
    {
        [XmlElement("entry")]
        public List<AnimeEntry> Entries { get; set; } = new List<AnimeEntry>();
    }
}