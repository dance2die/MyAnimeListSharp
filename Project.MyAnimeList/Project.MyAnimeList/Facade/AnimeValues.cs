using System;
using Project.MyAnimeList.Test.Tests;

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

		public StatusEnum Status { get; set; }
	}
}