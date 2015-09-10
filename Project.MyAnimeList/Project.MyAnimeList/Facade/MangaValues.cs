using System;

namespace MyAnimeListSharp.Facade
{
	public class MangaValues
	{
		private int _chapter;

		public int Chapter
		{
			get { return _chapter; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Chapter", "Chapter value cannot be negative");
				_chapter = value;
			}
		}
	}
}