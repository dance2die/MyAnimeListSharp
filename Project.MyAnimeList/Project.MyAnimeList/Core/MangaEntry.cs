using System.Xml.Serialization;

namespace MyAnimeListSharp.Core
{
    public class MangaEntry : EntryBase
    {
        [XmlElement(ElementName = "chapters")]
        public int Chapters { get; set; }

        [XmlElement(ElementName = "volumes")]
        public int Volumes { get; set; }
    }
}