using System.Xml.Linq;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	public abstract class ValuesFormatter<T> : IFormatter<T> where T : MyAnimeListValues
	{
		protected IXmlFormatter _xmlFormatter;

		protected ValuesFormatter(IXmlFormatter xmlFormatter)
		{
			_xmlFormatter = xmlFormatter;
		}

		public abstract string Format(T value);

		protected XDocument AddContentToDocument(XElement content)
		{
			const string standalone = null;
			var declaration = new XDeclaration("1.0", "UTF-8", standalone);
			var document = new XDocument(declaration, content);

			return document;
		}
	}
}