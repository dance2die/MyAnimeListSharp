using System;

namespace MyAnimeListSharp.Util
{
	/// <summary>
	/// Format the date time to a string
	/// </summary>
	public interface IDateFormatter
	{
		string Format(DateTime dateTime);
	}
}