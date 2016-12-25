using System.Xml.Linq;

namespace MyAnimeListSharp.Formatters
{
    /// <summary>
    /// Convert XDocument to string
    /// </summary>
    public interface IXmlFormatter : IFormatter<XDocument>
    {
    }
}