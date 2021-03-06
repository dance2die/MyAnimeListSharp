using System;
using MyAnimeListSharp.Enums;

namespace MyAnimeListSharp.Core
{
    public class AnimeValues : MyAnimeListValues
    {
        private short _episode;
        private int _rewatchValue;
        private float _storageValue;
        private int _timesRewatched;

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

        public EnableRewatching EnableRewatching { get; set; }
    }
}