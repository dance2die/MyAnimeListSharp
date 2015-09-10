using System;

namespace MyAnimeListSharp.Facade
{
	public class AnimeValues
	{
		private short _episode;
		private int _downloadedEpisodes;
		private float _storageValue;
		private int _timesRewatched;
		private int _rewatchValue;

		public short Episode
		{
			get { return _episode; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Episode", "Episode value cannot be negative");
				_episode = value;
			}
		}

		public AnimeStatus AnimeStatus { get; set; }
		public Score Score { get; set; }

		public int DownloadedEpisodes
		{
			get { return _downloadedEpisodes; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("DownloadedEpisodes", "Downloaded Episodes value cannot be negative");
				_downloadedEpisodes = value;
			}
		}

		public int StorageType { get; set; }

		public float StorageValue
		{
			get { return _storageValue; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("StorageValue", "Storage value cannot be negative");
				_storageValue = value;
			}
		}

		public int TimesRewatched
		{
			get { return _timesRewatched; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("TimesRewatched", "TimesRewatched value cannot be negative");
				_timesRewatched = value;
			}
		}

		public int RewatchValue
		{
			get { return _rewatchValue; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("RewatchValue", "RewatchValue value cannot be negative");
				_rewatchValue = value;
			}
		}

		public DateTime DateStart { get; set; }
		public DateTime DateFinish { get; set; }
		public int Priority { get; set; }
		public EnableDiscussionEnum EnableDiscussion { get; set; }
		public EnableRewatchingEnum EnableRewatching { get; set; }
		public string Comments { get; set; }
		public string FansubGroup { get; set; }
		public string Tags { get; set; }
	}
}