using System.Xml.Linq;

namespace MyAnimeListSharp.Util
{
	public interface IXmlFormatter
	{
		string Format(XDocument document);
	}
}