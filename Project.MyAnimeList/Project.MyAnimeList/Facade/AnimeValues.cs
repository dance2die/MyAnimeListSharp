using System;

namespace MyAnimeListSharp.Facade
{
	public class AnimeValues
	{
		private short _episode;

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
	}
}