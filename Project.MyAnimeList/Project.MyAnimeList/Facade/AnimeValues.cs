using System;

namespace MyAnimeListSharp.Facade
{
	public class AnimeValues
	{
		private short _episode;
		private int _downloadedEpisodes;

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

		public StatusEnum Status { get; set; }
		public ScoreEnum Score { get; set; }

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
	}
}