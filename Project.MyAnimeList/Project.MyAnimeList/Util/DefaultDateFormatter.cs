using System;

namespace MyAnimeListSharp.Util
{
	/// <summary>
	/// Date formatter which formats date according to MyAnimeList.net specification
	/// </summary>
	public class DefaultDateFormatter : IDateFormatter
	{
		/// <summary>
		/// Format the date time according to MyAnimeList.net specification
		/// </summary>
		/// <remarks>http://myanimelist.net/modules.php?go=api#animevalues</remarks>
		public string Format(DateTime dateTime)
		{
			return dateTime.ToString("MMddyyyy");
		}
	}
}