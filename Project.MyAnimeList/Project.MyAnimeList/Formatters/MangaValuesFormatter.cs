using MyAnimeListSharp.ContentBuilders;
using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
    /// <summary>
    /// Format "MangaValues" object instance as an XML string
    /// </summary>
    public class MangaValuesFormatter : ValuesFormatter<MangaValues>
    {
        private readonly IValuesContentBuilder<MangaValues> _valuesContentBuilder;

        public MangaValuesFormatter()
            : this(new DefaultXmlFormatter(), new MangaValuesContentBuilder())
        {
        }

        /// <remarks>
        ///     This would need to be replaced with Ioc calls using Ninject in next release.
        /// </remarks>
        public MangaValuesFormatter(IXmlFormatter xmlFormatter, IValuesContentBuilder<MangaValues> valuesContentBuilder)
            : base(xmlFormatter)
        {
            _valuesContentBuilder = valuesContentBuilder;
        }

        public override string Format(MangaValues values)
        {
            var document = AddContentToDocument(_valuesContentBuilder.BuildContent(values));
            var xmlString = _xmlFormatter.Format(document);
            return xmlString;
        }
    }
}