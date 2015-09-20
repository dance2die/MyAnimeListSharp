using System;

namespace MyAnimeListSharp.Formatters
{
	/// <summary>
	///     Date formatter which formats date according to MyAnimeList.net specification
	/// </summary>
	public class DefaultDateTimeFormatter : IDateTimeFormatter
	{
		/// <summary>
		///     Format the date time according to MyAnimeList.net specification
		/// </summary>
		/// <remarks>http://myanimelist.net/modules.php?go=api#animevalues</remarks>
		public string Format(DateTime? dateTime)
		{
			if (!dateTime.HasValue)
				return string.Empty;
			return dateTime.Value.ToString("MMddyyyy");
		}
	}
}