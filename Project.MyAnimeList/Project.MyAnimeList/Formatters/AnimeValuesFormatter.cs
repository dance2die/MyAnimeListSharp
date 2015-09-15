using MyAnimeListSharp.ContentBuilders;
using MyAnimeListSharp.Core;
using MyAnimeListSharp.Facade;

namespace MyAnimeListSharp.Formatters
{
	public class AnimeValuesFormatter : ValuesFormatter<AnimeValues>
	{
		private readonly IValuesContentBuilder<AnimeValues> _valuesContentBuilder;

		/// <remarks>
		///     This would need to be replaced with Ioc calls using Ninject in next release.
		/// </remarks>
		public AnimeValuesFormatter()
			: this(new DefaultXmlFormatter(), new AnimeValuesContentBuilder())
		{
		}

		public AnimeValuesFormatter(IXmlFormatter xmlFormatter, IValuesContentBuilder<AnimeValues> valuesContentBuilder)
			: base(xmlFormatter)
		{
			_valuesContentBuilder = valuesContentBuilder;
		}

		public override string Format(AnimeValues values)
		{
			var document = AddContentToDocument(_valuesContentBuilder.BuildContent(values));
			var xmlString = _xmlFormatter.Format(document);
			return xmlString;
		}
	}
}