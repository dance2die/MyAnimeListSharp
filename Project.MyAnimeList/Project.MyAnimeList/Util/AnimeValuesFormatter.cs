using System.Xml.Linq;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.Util
{
	public class AnimeValuesFormatter : IFormatter<AnimeValues>
	{
		private readonly IXmlFormatter _xmlFormatter;
		private readonly IValuesContentBuilder<AnimeValues> _valuesContentBuilder;

		/// <remarks>
		/// This would need to be replaced with Ioc calls using Ninject in next release.
		/// </remarks>
		public AnimeValuesFormatter()
			: this(new DefaultXmlFormatter(), new AnimeValuesContentBuilder())
		{
		}

		public AnimeValuesFormatter(IXmlFormatter xmlFormatter, IValuesContentBuilder<AnimeValues> valuesContentBuilder)
		{
			_valuesContentBuilder = valuesContentBuilder;
			_xmlFormatter = xmlFormatter;
		}

		public string Format(AnimeValues values)
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
