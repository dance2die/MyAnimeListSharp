using System;

namespace MyAnimeListSharp.Facade
{
	public class MangaValues
	{
		private int _chapter;
		private int _volume;

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

		public int Volume
		{
			get { return _volume; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Volume", "Volume value cannot be negative");
				_volume = value;
			}
		}
	}
}