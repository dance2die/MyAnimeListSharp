using System;
using MyAnimeListSharp.Enums;

namespace MyAnimeListSharp.Core
{
    /// <summary>
    ///     Common properties between Anime/Manga values.
    /// </summary>
    public abstract class MyAnimeListValues
    {
        public Score Score { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
        public Priority Priority { get; set; }
        public EnableDiscussion EnableDiscussion { get; set; }
        public string Comments { get; set; }
        public string Tags { get; set; }
    }
}