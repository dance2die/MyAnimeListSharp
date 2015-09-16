using MyAnimeListSharp.Core;

namespace MyAnimeListSharp.Formatters
{
	/// <summary>
	/// Formatter without functionality.
	/// </summary>
	/// <remarks>Null Object pattern</remarks>
	public class NullValuesFormatter<T> : ValuesFormatter<T> where T : MyAnimeListValues
	{
		public NullValuesFormatter()
			: this(new DefaultXmlFormatter())
		{
		}

		public NullValuesFormatter(IXmlFormatter xmlFormatter)
			: base(xmlFormatter)
		{
		}

		public override string Format(T value)
		{
			return string.Empty;
		}
	}
}