using System.Xml.Serialization;

namespace MyAnimeListSharp.Core
{
    public class AnimeEntry : EntryBase
    {
        [XmlElement(ElementName = "episodes")]
        public int Episodes { get; set; }
    }
}