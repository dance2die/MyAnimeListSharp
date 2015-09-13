using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.Util
{
	public class MangaValuesFormatter : IFormatter<MangaValues>
	{
		private readonly IXmlFormatter _xmlFormatter;
		private readonly IValuesContentBuilder<MangaValues> _valuesContentBuilder;

		/// <remarks>
		/// This would need to be replaced with Ioc calls using Ninject in next release.
		/// </remarks>
		public MangaValuesFormatter()
			: this(new DefaultXmlFormatter(), new MangaValuesContentBuilder())
		{
		}

		public MangaValuesFormatter(IXmlFormatter xmlFormatter, IValuesContentBuilder<MangaValues> valuesContentBuilder)
		{
			_valuesContentBuilder = valuesContentBuilder;
			_xmlFormatter = xmlFormatter;
		}

		public string Format(MangaValues values)
		{
			XDocument document = AddContentToDocument(_valuesContentBuilder.BuildContent(values));
			var xmlString = _xmlFormatter.Format(document);
			return xmlString;
		}

		protected XDocument AddContentToDocument(XElement content)
		{
			const string standalone = null;
			var declaration = new XDeclaration("1.0", "UTF-8", standalone);
			var document = new XDocument(declaration, content);

			return document;
		}
	}
}