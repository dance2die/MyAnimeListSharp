using System;
using MyAnimeListSharp.Enums;

namespace MyAnimeListSharp.Core
{
	public class MangaValues : MyAnimeListValues
	{
		private int _chapter;
		private int _rereadValue;
		private int _retailVolumes;
		private int _timesReread;
		private int _volume;

		public int Chapter
		{
			get { return _chapter; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(Chapter), "Chapter value cannot be negative");
				_chapter = value;
			}
		}

		public int Volume
		{
			get { return _volume; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(Volume), "Volume value cannot be negative");
				_volume = value;
			}
		}

		public MangaStatus MangaStatus { get; set; }

		public int TimesReread
		{
			get { return _timesReread; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(TimesReread), "TimesReread value cannot be negative");

				// 255 is the value that is set when the value is set to above 255 on MyAnimeList.net
				if (value > 255)
					throw new ArgumentOutOfRangeException(nameof(TimesReread), "TimesReread value should be less than or equal to 255");
				_timesReread = value;
			}
		}

		public string ScanGroup { get; set; }

		public int RetailVolumes
		{
			get { return _retailVolumes; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(RetailVolumes), "RetailVolumes value cannot be negative");
				_retailVolumes = value;
			}
		}

		public int RereadValue
		{
			get { return _rereadValue; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(RereadValue), "RetailVolumes value cannot be negative");
				_rereadValue = value;
			}
		}

		public EnableRereading EnableRereading { get; set; }
	}
}